<template>
    <div id="boxrow" class="row container m-auto pt-5">
        <div id="welcome" class="col-12 p-1">
            <ul id="example-1">
                <li>
                    <div class="row py-1 m-auto" style="    border: 1px solid #00000033;background:#ffae21; font-weight:bold;text-align:left; color:#464141">
                        <div class="col-3">Subject</div>
                        <div class="col-9">Preview</div>
                    </div>
                </li>
                <li v-for="item in items" :key="item.subject">
                    <router-link :to="{ name: 'Message', params: { id: item.id }}" id="read" class="row py-1 m-auto" style="background:#bfbfbf94;text-align:left; color:#0000007a;font-weight:400" v-if="!item.unread">
                        <div class="col-3">{{ item.subject }}</div>
                        <div class="col-9">{{ item.content.length &lt; 40? item.content : (item.content.substring(0,40)+"...") }}</div>
                    </router-link>
                    <router-link :to="{ name: 'Message', params: { id: item.id }}" id="nread" class="row py-1 m-auto" style="background:white; font-weight:bold;text-align:left; color:black" v-if="item.unread" @click="read(item)">
                        <div class="col-3">{{ item.subject }}</div>
                        <div class="col-9">{{ item.content.length &lt; 40? item.content : (item.content.substring(0,40)+"...") }}</div>
                    </router-link>
                </li>
            </ul>
        </div>
    </div>
</template>
<script>
import axios from 'axios'

export default{
    data: function () {
        return{
            items: []
        }
    },

    mounted () {
       axios.get('http://localhost:5000/api/messages').then((response)=>{
        this.items = response.data;
    });
        
    },
    methods:{
        read(item){
            item.unread= false
            axios.put('http://localhost:5000/api/Messages/'+item.id, {
                unread: item.unread
                })
                .then((response) => {
                console.log(response);
                }, (error) => {
                console.log(error);
            });
        }
    }
}
</script>

<style scoped>
#boxrow{
    justify-content: center;
    display: flex;
    align-items: center;
}
#welcome{
    border: 1px solid #00000075;
    background: rgb(34, 105, 187);
    color: white;
    border-radius: 5px;
    box-shadow: 6px 8px 20px 10px #0000003d;
    height: 80vh;
}
#welcome a{
    font-weight: bold;
    color: white;
    font-size: 16px;
    border: 1px solid #00000033;
    background: radial-gradient(#399d50, #28a745);
}
#welcome a:hover {
    /* color: #0056b3; */
    text-decoration: none!important;
}
ul {
    margin-bottom: 0;
    padding-inline-start: 0px;
    list-style-type: none;
    background: #8ec2ff;
}
#read:hover {
    background: #ffffff80 !important;
}
#nread:hover {
   background: #ffffff9d !important;
}
</style>
