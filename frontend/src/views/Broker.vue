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
        <formcard title="BUY" :energyType="energyTypes[energyRadio]" :marketValue="marketBuyPrice" :formData="form.buy" />
        <formcard title="SELL" :energyType="energyTypes[energyRadio]" :marketValue="marketSellPrice" :formData="form.sell"/>
      </div>
      <div>
        <datatable title="BUY ORDERS" :energyType="energyTypes[energyRadio]" :orderBookData="orderBookData.buy" />
        <datatable title="SELL ORDERS" :energyType="energyTypes[energyRadio]" :orderBookData="orderBookData.sell" />
      </div>
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
    energyRadio: energyEnum.EnergyType.WindPower.value,
    energyTypes: energyEnum.EnergyType,
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
      return this.orderBookData.buy[0].price;
    },
    marketSellPrice() {
      return this.orderBookData.sell[0].price;
    },
  },
  methods: {
    getBalances() {
      apiService.getBalances()
        .then(body => {
          console.log(body);
          this.balances = body.data;
        });
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
      this.form.recipientEmail = "gabriel@mantle.services";
      this.form.senderEmail = "philippe@mantle.services";
    },
    setFormEmailsSend() {
      this.form.recipientEmail = "gabriel@mantle.services";
      this.form.senderEmail = "philippe@mantle.services";
    },
    buyEnergy() {
      this.setFormEmailsReceive();
      apiService.transferAmount(this.form)
        .then(body => {
          console.log(body);

        });
    },
    sellEnergy() {
      apiService.transferAmount(this.form)
        .then(body => {
          console.log(body);

        });
    },
    fetchFactoryIds() {
      apiService.getAssets()
        .then(body => {
          console.log(body.data);
          this.dataLoaded = true;
        });
    },
    mockNewOrder() {
      this.$nextTick(function () {
        window.setInterval(() => {
          this.orderBookData.buy.pop();
          this.orderBookData.buy.unshift(
            {
              price: utils.generateRandomNumber(this.orderBookData.buy[0].price + 0.001, this.orderBookData.buy[0].price + 5),
              amount: utils.generateRandomNumber(0.001, 3.123),
            }
          );
          this.orderBookData.sell.pop();
          this.orderBookData.sell.unshift(
            {
              price: utils.generateRandomNumber(this.orderBookData.sell[0].price - 0.001, this.orderBookData.sell[0].price - 2),
              amount: utils.generateRandomNumber(0.001, 2.123),
            }
          );
        }, 5000);
      });
    },
    loadInitData() {
      this.orderBookData.buy = [];
      this.orderBookData.sell = [];
      this.orderBookData.buy = utils.generateInitialData(500, 1000, 0.001, 2.123, 30, true);
      this.orderBookData.sell = utils.generateInitialData(500, 1000, 0.001, 3.123, 30, false);
    },
  },
  mounted(){
    this.loadInitData();
    this.fetchFactoryIds();
    this.mockNewOrder();
  },
  // updated() {
  //   console.log("updated");
  // }
};
</script>

<style lang="scss" scoped>
</style>