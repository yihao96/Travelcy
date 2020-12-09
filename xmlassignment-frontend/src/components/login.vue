<template>
    <div id="login" class="container">
        <div class="row">
            <div class="col-md-6 col-md-offset-3">
                <div class="lead-form">
                <h1 class="text-center">Login</h1>
                <hr />
                    <div class="row">
                        <div class="col-md-6">
                            <input type="text" class="form-control" name="username" v-model="input.username" placeholder="Username" />
                        </div>
                        <div class="col-md-6">
                            <input type="password" class="form-control" name="password" v-model="input.password" placeholder="Password" />
                        </div>
                    </div>
                    <div class="row col">
                        <span>{{ errMsg }}</span>
                    </div>
                    <div class="row">
                        <div class="col">
                            <button type="button" class="btn btn-primary" v-on:click="login()">Login</button>
                            <button type="button" class="btn btn-primary" v-on:click="register()">Register</button>
                            <button type="button" class="btn btn-secondary" v-on:click="clear()">Clear</button>
                        </div>
                    </div>
                </div>
            </div>
        </div>
        <p>{{ resMsg }}</p>   
    </div>
</template>

<script>
export default {
    name: 'Login',
    data() {
        return {
            input: {
                id: 100,
                username: "",
                password: ""
            },
            errMsg: '',
            resMsg: '',
            xmluser: '',
            xmlpw: ''
        }
    },
    methods: {
        login() {
            if (this.input.username != "" && this.input.password != "") {
                this.$http.get('https://localhost:7001/users-api/users/' + this.input.username)
                .then(response => {
                    console.log(response)
                    this.xmluser = response.data.username
                    this.xmlpw = response.data.password
                    if (this.input.username == this.xmluser && this.input.password == this.xmlpw) {
                        this.$emit("authenticated", true)
                        this.$emit("currentuser", this.input.username)
                        this.$router.replace({ name: "flight" })
                        this.errMsg = ''
                    } else {
                        this.errMsg = 'The username and/or password is incorrect'
                    }
                })
                .catch(error => {
                    console.log(error)
                })
            } else {
                this.errMsg = 'A username and password must be present'
            }
        },
        register() {
            if (this.input.username != "" && this.input.password != "") {
                this.registerApi()
                this.errMsg = ''
            } else {
                this.errMsg = 'A username and password must be present'
            }
        },
        clear() {
            this.input.username = ''
            this.input.password = ''
            this.errMsg = ''
            this.resMsg = ''
        },
        registerApi() {
            this.$http.post('https://localhost:7001/users-api/users', this.input)
            .then(response => {
                this.resMsg = response
                console.log(response)
            })
        }
    }
}
</script>

<style scoped>
#login {
    /* width: 500px; */
    /* border: 1px solid #cccccc; */
    /* background-color: #ffffff; */
    /* margin: auto;
    margin-top: 100px;
    padding: 20px; */
}
span {
    /* padding-top: 10px; */
    margin-top: 10px;
    margin-bottom: 10px;
    color: red;
    font-size: 10pt
}
.lead-form {
    background-color: rgba(255, 255, 255, 0.6);
    border-radius: 5px;
    padding: 10px 50px 30px 50px;
    margin-top: 100px;
}
</style>

