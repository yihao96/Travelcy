<template>
    <div id="home">
        <h1>Show Users</h1>
        <p>{{ msg }}</p>
        <p>{{ someData }}</p>
        <table>
            <thead>
                <tr>
                    <th>ID</th>
                    <th>Username</th>
                    <th>Password</th>
                </tr>
            </thead>
            <tbody>
                <tr>
                    <td>{{ id }}</td>
                    <td>{{ username }}</td>
                    <td>{{ password }}</td>
                </tr>
            </tbody>
        </table>
    </div>
</template>

<script>
export default {
    name: 'Home',
    data() {
        return {
            msg: 'Welcome to user list',
            someData: '',
            id: '',
            username: '',
            password: ''
        }
    },
    mounted() {
        this.$http.get('https://localhost:5001/api/users')
        .then(response => {
            this.someData = response.data
            this.id = response.data.id
            this.username = response.data.username
            this.password = response.data.password
        })
        .catch(error => {
            console.log(error)
        })
    },
    created() {
        
    }
}
</script>

