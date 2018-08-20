<template>
  <div class="create-btn-container">
    <md-dialog :md-active.sync="showDialog">
      <md-dialog-title>Transfer energy ressources</md-dialog-title>
      <form novalidate class="md-layout" @submit.prevent="validateUser">
      <md-card class="md-layout-item">
        <md-card-area md-inset>
          <md-card-content>
            <h3 class="md-subheading">
              <md-icon>call_made</md-icon>
              Energy to transfer
            </h3>
            
            <div class="md-layout-item md-small-size-100">
                <md-field>
                  <!-- <label for="energyType">Asset</label> -->
                  <span>{{ energyDisplayName }}</span>
                </md-field>
            </div>

            <!-- <md-field :class="getValidationClass('email')">
                <label for="email">Email</label>
                <md-input type="email" name="email" id="email" autocomplete="email" v-model="form.email" :disabled="sending" />
                <span class="md-error" v-if="!$v.form.email.required">The email is required</span>
                <span class="md-error" v-else-if="!$v.form.email.email">Invalid email</span>
            </md-field> -->
            <div class="md-layout md-gutter">
                <div class="md-layout-item md-small-size-100">
                    <md-field :class="getValidationClass('quantity')">
                        <label for="quantity">Quantity</label>
                        <md-input type="number" id="quantity" name="quantity" autocomplete="quantity" v-model="form.quantity" :disabled="sending" />
                        <span class="md-error" v-if="!$v.form.quantity.required">The quantity is required</span>
                        <span class="md-error" v-else>Invalid quantity</span>                    
                    </md-field>                
                </div>
                <div class="md-layout-item md-small-size-100">
                  <md-field>
                    <span>kWh</span>
                  </md-field>     
                </div>
            </div>
          </md-card-content>
        </md-card-area>
        <md-card-content>
          <h3 class="md-subheading">
            <md-icon>call_received</md-icon>
            Money to receive
          </h3>
          <md-field :class="getValidationClass('email')">
              <label for="email">Recipient</label>
              <md-input type="email" name="email" id="email" autocomplete="email" v-model="form.email" :disabled="sending" />
              <span class="md-error" v-if="!$v.form.email.required">The email is required</span>
              <span class="md-error" v-else-if="!$v.form.email.email">Invalid email</span>
          </md-field>
          <div class="md-layout md-gutter">
              <div class="md-layout-item md-small-size-100">
                  <md-field :class="getValidationClass('amount')">
                      <label for="amount">Amount</label>
                      <md-input type="number" id="amount" name="amount" autocomplete="amount" v-model="form.amount" :disabled="sending" />
                      <span class="md-error" v-if="!$v.form.quantity.required">The amount is required</span>
                      <span class="md-error" v-else>Invalid amount</span>                    
                  </md-field>                
              </div>
              <div class="md-layout-item md-small-size-100">
                <md-field>
                  <span>CAD</span>
                </md-field>     
              </div>
          </div>
        </md-card-content>
        <md-card-actions>
          <md-button type="submit" class="md-primary" :disabled="sending">Transfer energy</md-button>
        </md-card-actions>
      </md-card>
      <md-snackbar md-position="left" :md-duration="5000" :md-active.sync="showSnackbar" md-persistent>
        <span>{{ snackBarMsg }}</span>
      </md-snackbar>
      </form>
    </md-dialog>
    <md-button class="md-raised md-primary" @click="showDialog=true">
      <md-icon>swap_horiz</md-icon>
      <span>sell</span>
    </md-button>
    <!-- <md-button class="md-dense md-raised md-primary create-btn" @click="showDialog=true">
        <md-icon>add_circle_outline</md-icon> Create a green credit
    </md-button> -->
  </div>
</template>

<script>
  import * as apiService from "../services/apiService";
  import { validationMixin } from 'vuelidate';
  import {
    required,
    email,
    minLength,
    maxLength,
    minValue,
  } from 'vuelidate/lib/validators';
  export default {
    name: "transferbtn",
    mixins: [validationMixin],
    props: ['energyDisplayName', 'assetId'],
    props: {
      energyDisplayName: String,
      assetId: String,
    },
    data: () => ({
      showDialog: false,
      dialogValue: null,
      form: {
        energyId: null,
        email: null,
        quantity: null,
        amount: null,
      },
      assetCreated: false,
      sending: false,
      snackBarMsg: null,
      showSnackbar: false,
    }),
    validations: {
      form: {
        quantity: {
          required,
          maxLength: maxLength(3),
          minValue: minValue(1),
        },
        amount: {
          required,
          maxLength: maxLength(3),
          minValue: minValue(1),
        },
        email: {
          required,
          email
        }
      }
    },
    methods: {
      getValidationClass (fieldName) {
        const field = this.$v.form[fieldName]

        if (field) {
          return {
            'md-invalid': field.$invalid && field.$dirty
          }
        }
      },
      clearForm () {
        this.$v.$reset()
        this.form.quantity = null
        this.form.amount = null
        this.form.email = null
      },
      issueAmount () {
        this.form.energyId = this.assetId;
        this.sending = true
        apiService.issueAmount(this.form)
          .then(() => {            
            this.assetCreated = true;
            this.snackBarMsg = "Energy issued.";
            this.showSnackbar = true;
            this.sending = false;
            this.clearForm();
          }).catch((error) => {
            if (error.response) {
                this.snackBarMsg = error.response.data;
            } else if (error.request) {
                this.snackBarMsg = error.request;
            } else {
                this.snackBarMsg = error.message;
            }
            this.showSnackbar = true;
            this.sending = false;
            this.clearForm();
          });
      },
      validateUser () {
        this.$v.$touch()

        if (!this.$v.$invalid) {
          this.issueAmount()
        }
      }
    }
  };
</script>

<style lang="scss" scoped>
.create-btn-container {
    float: right;
}
.create-btn {
    height: 50px;
}
</style>