<template>
    <div id="boxrow" class="row container m-auto">
        <div id="welcome" class="col-6 p-5">
            <h1>
                Hello, {{username}}
            </h1>
            <h3 class="py-3">
                You have {{unread}} undread messages
            </h3>
            <router-link to="/inbox" class="px-3 py-2">Go to inbox</router-link>
        </div>
    </div>
</template>
<script>

export default ({
    data: function() {
        return{
            username:'',
            unread:''
        }
    },
    mounted() {
        this.username = localStorage.getItem('username')
        this.unread = localStorage.getItem('unread')
        console.log(this.unread)
    }
})
</script>

<style scoped>
#boxrow{
    justify-content: center;
    display: flex;
    height: 50%;
    align-items: center;
}
#welcome{
    border: 1px solid #00000075;
    background: rgb(34, 105, 187);
    color: white;
    border-radius: 10px;
    box-shadow: 6px 8px 20px 10px #00000075;
}
#welcome a{
    font-weight: bold;
    color: white;
    font-size: 20px;
    border: 1px solid black;
    background: radial-gradient(#399d50, #28a745);
    border-radius: 5px;
}
#welcome a:hover {
    text-decoration: none;
    box-shadow: 0 0 20px 7px #d9e79d66;
}
</style>
