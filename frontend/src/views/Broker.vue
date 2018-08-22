<template>
  <div>
    <headerbar/>
    <titlecard title="Broker"/>
    <div v-if="dataLoaded">
      <div>
        <md-radio
          v-for="(item) in Object.values(this.energyTypes)"
          :key="item.shortName"
          v-model="energyRadio"
          :value="item.value">
          {{ item.longName }}
        </md-radio>
      </div>
      <div>
        <formcard title="BUY" :energyType="energyTypes[energyRadio]" :marketValue="marketBuyPrice" :formData="form.buy" :onSubmit="buyEnergy" :sending="sendingBuy" />
        <formcard title="SELL" :energyType="energyTypes[energyRadio]" :marketValue="marketSellPrice" :formData="form.sell" :onSubmit="sellEnergy" :sending="sendingSell"/>
      </div>
      <div>
        <datatable title="BUY ORDERS" :energyType="energyTypes[energyRadio]" :orderBookData="buyOrderBook" />
        <datatable title="SELL ORDERS" :energyType="energyTypes[energyRadio]" :orderBookData="sellOrderBook" />
      </div>
      <md-snackbar md-position="left" :md-duration="3000" :md-active.sync="showSnackbar" md-persistent>
        <span>{{ snackBarMsg }}</span>
      </md-snackbar>
    </div>
    <div v-else>
      <md-progress-spinner class="md-accent" md-mode="indeterminate"></md-progress-spinner>
    </div>
  </div>
</template>

<script>
import * as apiService from "../services/apiService";
import * as utils from "@/utils/utils";
import * as energyEnum from "@/enum/EnergyType";
import datatable from "@/components/OrderDataTable";
import headerbar from "@/components/HeaderBar";
import titlecard from "@/components/TitleCard";
import formcard from "@/components/FormCard";
export default {
  name: "broker",
  components: {
    datatable,
    headerbar,
    titlecard,
    formcard,
  },
  data: () => ({
    balances: null,
    dataLoaded: false,
    snackBarMsg: null,
    showSnackbar: false,
    energyRadio: energyEnum.EnergyType.WindPower.value,
    energyTypes: energyEnum.EnergyType,
    energyAssets: null,
    currencyAssets: null,
    recipientEmail: null,
    senderEmail: null,
    sendingBuy: false,
    sendingSell: false,
    form: {
      buy: {
        price: null,
        amount: null,
      },
      sell: {
        price: null,
        amount: null,
      },
    },
    orderBookData: {
      buy: [
        {
          price: 1000,
          amount: 20,
        }
      ],
      sell: [
        {
          price: 500,
          amount: 50,
        }
      ],
    },
  }),
  watch: {
    balances(newData, oldData) {
      this.dataLoaded = true;
    },
    energyRadio(newData, oldData) {
      this.loadInitData();
      this.resetForm();
    }
  },
  computed: {
    marketBuyPrice() {
      return this.orderBookData.sell[0].price;
    },
    marketSellPrice() {
      return this.orderBookData.buy[0].price;
    },
    buyOrderBook() {
      let currentSum = 0;
      let results = [];
      this.orderBookData.buy.forEach(e => {
        currentSum += e.price * e.amount;
        results.push(
          {
            price: e.price,
            amount: e.amount,
            total: currentSum,
          }
        )
      });
      return results;
    },
    sellOrderBook() {
      let currentSum = 0;
      let results = [];
      this.orderBookData.sell.forEach(e => {
        currentSum += e.price * e.amount;
        results.push(
          {
            price: e.price,
            amount: e.amount,
            total: currentSum,
          }
        )
      });
      return results;
    },    
  },
  methods: {
    getBalances() {
      apiService.getBalances()
        .then(body => {
          this.balances = body.data;
        });
    },
    resetBuyForm() {
      this.form = {
        buy: {
          price: null,
          amount: null,
        },
      };
    },
    resetSellForm() {
      this.form = {
        sell: {
          price: null,
          amount: null,
        },
      };
    },
    resetForm() {
      this.form = {
        buy: {
          price: null,
          amount: null,
        },
        sell: {
          price: null,
          amount: null,
        },
      };
    },
    setFormEmailsReceive() {
      this.recipientEmail = "philippe@mantle.services";
      this.senderEmail = "gabriel@mantle.services";
    },
    setFormEmailsSend() {
      this.recipientEmail = "gabriel@mantle.services";
      this.senderEmail = "philippe@mantle.services";
    },
    getApiForm(assetId, opsType, amountType) {
      return {
        senderEmail: this.senderEmail,        
        amount: amountType == "price" ? this.form[opsType].price *  this.form[opsType].amount: this.form[opsType][amountType],
        assetId: assetId,
        recipientEmail: this.recipientEmail,
      }
    },
    buyEnergy() {
      this.setFormEmailsReceive();
      this.sendingBuy = true;
      const assetId = this.energyAssets.find(e => e.name == energyEnum.EnergyType[this.energyRadio].shortName).id;
      apiService.transferAmount(this.getApiForm(assetId, "buy", "amount"))
        .then(() => {
          console.log("first transfer successful");
          this.setFormEmailsSend();        
          apiService.transferAmount(this.getApiForm(this.currencyAssets[0].id, "buy", "price"))
            .then(() => {
              this.snackBarMsg = "Transaction Sucessful";
              console.log("second transfer successful");
              this.showSnackbar = true;
              this.sendingBuy = false;
              this.resetForm();
            })
            .catch((error) => {
              if (error.response) {
                  this.snackBarMsg = error.response.data;
              } else if (error.request) {
                  this.snackBarMsg = error.request;
              } else {
                  this.snackBarMsg = error.message;
              }
              this.showSnackbar = true;
              this.sendingBuy = false;
              this.resetForm();
            });
        })
        .catch((error) => {
          if (error.response) {
              this.snackBarMsg = error.response.data;
          } else if (error.request) {
              this.snackBarMsg = error.request;
          } else {
              this.snackBarMsg = error.message;
          }
          this.showSnackbar = true;
          this.sendingBuy = false;
          this.resetForm();
        });
    },
    sellEnergy() {
      this.setFormEmailsReceive();
      this.sendingSell = true;    
      apiService.transferAmount(this.getApiForm(this.currencyAssets[0].id, "sell", "price"))
        .then(() => {
          console.log("first transfer successful");
          this.setFormEmailsSend();
          const assetId = this.energyAssets.find(e => e.name == energyEnum.EnergyType[this.energyRadio].shortName).id;
          apiService.transferAmount(this.getApiForm(assetId, "sell", "amount"))
            .then(() => {
              this.snackBarMsg = "Transaction Sucessful";
              console.log("second transfer successful");
              this.showSnackbar = true;
              this.sendingSell = false;
              this.resetForm();
            })
            .catch((error) => {
              if (error.response) {
                  this.snackBarMsg = error.response.data;
              } else if (error.request) {
                  this.snackBarMsg = error.request;
              } else {
                  this.snackBarMsg = error.message;
              }
              this.showSnackbar = true;
              this.sendingSell = false;
              this.resetForm();
            });
        })
        .catch((error) => {
          if (error.response) {
              this.snackBarMsg = error.response.data;
          } else if (error.request) {
              this.snackBarMsg = error.request;
          } else {
              this.snackBarMsg = error.message;
          }
          this.showSnackbar = true;
          this.sendingSell = false;
          this.resetForm();
        });
    },
    fetchAssetIds() {
      apiService.getAssets()
        .then(body => {
          this.energyAssets = body.data.filter(asset => Object.values(energyEnum.EnergyType).map(e => e.shortName).includes(asset.name));
          this.currencyAssets = body.data.filter(asset => asset.name == "CAD");
          this.dataLoaded = true;
        });
    },
    mockNewOrder() {
      this.$nextTick(function () {
        window.setInterval(() => {
          this.orderBookData = utils.generateData(3000, 60);
          // this.orderBookData.buy.pop();
          // this.orderBookData.buy.unshift(
          //   {
          //     price: utils.generateRandomNumber(this.orderBookData.buy[0].price + 0.001, this.orderBookData.buy[0].price + 5),
          //     amount: utils.generateRandomNumber(0.001, 3.123),
          //   }
          // );
          // this.orderBookData.sell.pop();
          // this.orderBookData.sell.unshift(
          //   {
          //     price: utils.generateRandomNumber(this.orderBookData.sell[0].price - 0.001, this.orderBookData.sell[0].price - 2),
          //     amount: utils.generateRandomNumber(0.001, 2.123),
          //   }
          // );
        }, 500);
      });
    },
    loadInitData() {
      this.orderBookData.buy = [];
      this.orderBookData.sell = [];
      this.orderBookData = utils.generateData(3000, 60);
      // this.orderBookData.buy = utils.generateInitialData(5000, 10000, 0.001, 2.123, 30, true);
      // this.orderBookData.sell = utils.generateInitialData(5000, 10000, 0.001, 3.123, 30, false);
    },
  },
  mounted(){
    this.loadInitData();
    this.fetchAssetIds();
    this.mockNewOrder();    
  },
  // updated() {
  //   console.log("updated");
  // }
};
</script>

<style lang="scss" scoped>
</style>