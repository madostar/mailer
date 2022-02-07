<template>
  <div id="nav" class="row p-2">
    <router-link class="col-1 py-1" to="/">Home</router-link>
    <span class="col-10 pl-5 py-2"> <font-awesome-icon :icon="['fas', 'user-secret']" /> Dear {{username}}, you have currently <strong style="color:black"> {{unread}} </strong> unread messages!</span>
  </div>
  <router-view/>
</template>

<script>

import axios from 'axios'

export default({
  data: function (){
    return{
      items:[],
      unread:0,
      username:""
    }
  },
  mounted() {
    
    this.getItems();
    
    setTimeout(this.setStore, 1000);
    this.items= localStorage.getItem('messages')

    this.username = localStorage.getItem('username')
    
    
  },
  methods:{
    getItems(){
      axios.get('http://localhost:5000/api/messages').then((response)=>{
        this.items = response.data;
    });
    },
    setStore(){
      for (let index = 0; index < this.items.length; index++) {
        if (this.items[index].unread) {
          this.unread++;
        }
      }
      var fixed = [];
      for (let index = 0; index < this.items.length; index++) {
        var fix ={
          id: this.items[index].id,
          subject: this.items[index].subject,
          content: this.items[index].content,
          unread: this.items[index].unread
        }
        fixed.push(fix)
        
      }
        
      localStorage.setItem('username', 'Mike');
      localStorage.setItem('messages', JSON.stringify(this.items));
      localStorage.setItem('unread', this.unread)
    }
  }
})
</script>

<style>
#app {
  font-family: Avenir, Helvetica, Arial, sans-serif;
  -webkit-font-smoothing: antialiased;
  -moz-osx-font-smoothing: grayscale;
  text-align: center;
  color: #2c3e50;
  height: 100%;
  background: linear-gradient(0deg, #b5b5b5, #dfdfdf);
}

#nav {
  background: rgb(34, 105, 187);
  color: white;
  justify-content: center;
  box-shadow: 0px 3px 14px black;
}

#nav a {
  font-weight: bold;
  color: white;
  font-size: 20px;
  border: 1px solid black;
  background: #ffae21;
  border-radius: 5px;
}

#nav a:hover {
    /* color: #0056b3; */
    text-decoration: none;
    box-shadow: 0 0 3px 1px #d9e79d66;
}

#nav span {
  font-weight: bold;
  text-align: left;
  /* padding: 0 20px; */
}

/* #nav a.router-link-exact-active {
  color: #42b983;
} */
</style>
