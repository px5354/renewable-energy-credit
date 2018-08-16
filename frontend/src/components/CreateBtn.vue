<template>
  <div class="create-btn-container">
    <md-dialog :md-active.sync="showDialog">
      <md-dialog-title>Create new green credit</md-dialog-title>
      <form novalidate class="md-layout" @submit.prevent="validateUser">
      <md-card class="md-layout-item">
        <md-card-content>
            <!-- <div class="md-layout md-gutter">
                <div class="md-layout-item md-small-size-100">
                <md-field :class="getValidationClass('firstName')">
                    <label for="first-name">First Name</label>
                    <md-input name="first-name" id="first-name" autocomplete="given-name" v-model="form.firstName" :disabled="sending" />
                    <span class="md-error" v-if="!$v.form.firstName.required">The first name is required</span>
                    <span class="md-error" v-else-if="!$v.form.firstName.minlength">Invalid first name</span>
                </md-field>
                </div>

                <div class="md-layout-item md-small-size-100">
                <md-field :class="getValidationClass('lastName')">
                    <label for="last-name">Last Name</label>
                    <md-input name="last-name" id="last-name" autocomplete="family-name" v-model="form.lastName" :disabled="sending" />
                    <span class="md-error" v-if="!$v.form.lastName.required">The last name is required</span>
                    <span class="md-error" v-else-if="!$v.form.lastName.minlength">Invalid last name</span>
                </md-field>
                </div>
            </div> -->

            <div class="md-layout-item md-small-size-100">
                <md-field :class="getValidationClass('energyType')">
                    <label for="energyType">Energy Type</label>
                    <md-select name="energyType" id="energyType" v-model="form.energyType" md-dense :disabled="sending">
                    <md-option value="W">Wind power</md-option>
                    <md-option value="H">Hydropower</md-option>
                    <md-option value="S">Solar energy</md-option>
                    <md-option value="G">Geothermal energy</md-option>
                    <md-option value="B">Bio energy</md-option>
                    <md-option value="E">Energy storage</md-option>
                    </md-select>
                    <span class="md-error">The energy type is required</span>
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
                        <label for="energyType">Unit</label>
                        <md-select name="unit" id="unit" md-dense>
                        <md-option value="kWh">kWh</md-option>
                        <md-option value="Wh">Wh</md-option>
                        </md-select>
                    </md-field>     
                </div>
            </div>
          </md-card-content>
        <md-card-actions>
          <md-button type="submit" class="md-primary" :disabled="sending">Create green credit</md-button>
        </md-card-actions>
      </md-card>
      </form>
    </md-dialog>
    <md-button class="md-icon-button md-raised md-primary" @click="showDialog=true">
      <md-icon>add</md-icon>
    </md-button>
    <!-- <md-button class="md-dense md-raised md-primary create-btn" @click="showDialog=true">
        <md-icon>add_circle_outline</md-icon> Create a green credit
    </md-button> -->
  </div>
</template>

<script>
  import { validationMixin } from 'vuelidate'
  import {
    required,
    email,
    minLength,
    maxLength,
    minValue,
  } from 'vuelidate/lib/validators'
  export default {
    name: "createbtn",
    mixins: [validationMixin],
    data: () => ({
      showDialog: false,
      dialogValue: null,
      form: {
        energyType: null,
        quantity: null,
        units: null,
      },
      userSaved: false,
      sending: false,
      lastUser: null
    }),
    validations: {
      form: {
        quantity: {
          required,
          maxLength: maxLength(3),
          minValue: minValue(1),
        },
        energyType: {
          required
        },
        // email: {
        //   required,
        //   email
        // }
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
        this.form.energyType = null
      },
      saveUser () {
        this.sending = true

        // Instead of this timeout, here you can call your API
        window.setTimeout(() => {
          this.lastUser = `${this.form.firstName} ${this.form.lastName}`
          this.userSaved = true
          this.sending = false
          this.clearForm()
        }, 1500)
      },
      validateUser () {
        this.$v.$touch()

        if (!this.$v.$invalid) {
          this.saveUser()
        }
      }
    }
  };
</script>

<style lang="scss" scoped>
.create-btn-container {
    padding-top: 100px;
    float: right;
}
.create-btn {
    height: 50px;
}
</style>