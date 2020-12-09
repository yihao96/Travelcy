<template>
    <div id="secure" class="container">
        <div class="row">
            <div class="col-md-12 col-md-offset-3">
                <div class="lead-form">
                    <h1 class="text-center">Hotels Lookup</h1>
                    <hr>
                    <div class="row">
                        <div class="col-md-4">
                            <input type="text" class="form-control" placeholder="asdasd" v-model="origin">
                            <span class="loc-span">{{msg}}</span>
                        </div>
                        <div class="col-md-4">
                            <input type="text" class="form-control" placeholder="Destination" v-model="destination">
                            <span class="loc-span">{{msg}}</span>
                        </div>
                    </div>
                    <div class="row">
                        <div class="col-md-4">
                            <input type="text" class="form-control" placeholder="Date dd-mm-yyyy" v-model="date">
                            <span class="loc-span">{{msg}}</span>
                        </div>
                        <div class="col-md-4">
                            <span class="loc-span">{{resMsg}}</span>
                        </div>
                    </div>
                    <div class="row">
                        <div class="col-md-6">
                            <button class="btn btn-primary btn-block" v-on:click="searchFlight()">Search</button>
                        </div>
                        <div class="col-md-6">
                            <button class="btn btn-secondary btn-block" v-on:click="clear()">Clear</button>
                        </div>
                    </div>
                </div>
            </div>
        </div>
        <div class="row">
            <div class="col-md-12">
                <div class="lead-form">
                    <h1 class="text-center">Available Flights</h1>
                    <table class="table table-dark">
                        <thead>
                            <tr>
                                <th scope="col">Airline</th>
                                <th scope="col">Date</th>
                                <th scope="col">Time</th>
                                <th scope="col">Origin</th>
                                <th scope="col">Destination</th>
                                <th scope="col">Price</th>
                                <th scope="col">Stop</th>
                                <th scope="col">Available Seats</th>
                                <th scope="col"></th>
                            </tr>
                        </thead>
                        <tbody>
                            <tr v-for="flights in flightDetails">
                                <td>{{flights.airline}}</td>
                                <td>{{flights.departure_date}}</td>
                                <td>{{flights.departure_time}}</td>
                                <td>{{flights.origin}}</td>
                                <td>{{flights.destination}}</td>
                                <td>{{flights.price}}</td>
                                <td>{{flights.stop}}</td>
                                <td>{{flights.seats}}</td>
                                <td>
                                    <button class="btn btn-primary" v-on:click="bookNow(flights.id)">Book</button>
                                </td>
                            </tr>
                        </tbody>
                    </table>
                </div>
            </div>
        </div>
    </div>
</template>

<script>
export default {
    name: 'Secure',
    data() {
        return {
            flightDetails: {
            },
            flight: {
                flightId: '',
                flightAirline: '',
                flightDate: '',
                flightTime: '',
                flightOrigin: '',
                flightDestination: '',
                flightPrice: '',
                flightStop: ''
            },
            origin: '',
            destination: '',
            date: '',
            msg: '',
            resMsg: ''
        }
    },
    methods: {
        searchFlight() {
            if (this.origin != "" && this.destination != "" && this.date != "") {
                this.$http.get('https://localhost:7001/flights-api/flights/byDate?date=' + this.date + '&origin=' + this.origin + '&destination=' + this.destination)
                .then(response => {
                    console.log(response)
                    if (response.status == 200) {
                        this.resMsg = ''
                        this.flightDetails = response.data
                    } else {
                        this.resMsg = 'No flight found'
                    }
                })
                .catch(error => {
                    console.log(error)
                })
            } else {
                this.resMsg = 'Origin, Destination and Date is required'
            }
        },
        bookNow(id) {
            this.$http.put('https://localhost:7001/flights-api/flights/bookFlight?id=' + id + '&seats=1')
            .then(response => {
                console.log(response)
                this.searchFlight()
            })
        },
        clear() {
            this.resMsg = ''
            this.origin = ''
            this.destination = ''
            this.date = ''
        }
    }
}
</script>

<style scoped>
#secure {
    /* background-color: #ffffff; */
    /* border: 1px solid #cccccc; */
    padding: 20px;
    /* margin-top: 10px; */
}
.lead-form {
    background-color: rgba(255, 255, 255, 0.6);
    border-radius: 5px;
    padding: 10px 50px 30px 50px;
    margin-top: 20px;
}
#submit-form {
  margin-top: 40px;
}
.form-control {
  margin-bottom: 3px;
}
span.loc-span {
  /* color: (#444); */
  color: red;
  /* text-transform: uppercase; */
  margin-left: 5px;
  margin-top: 10px;
  margin-bottom: 10px;
}
</style>

