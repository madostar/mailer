<template>
    <div id="boxrow" class="row container m-auto pt-5">
        <div id="welcome" class="col-12 p-1">
            <div id="msgbox" class="p-3">
                <div class="row pb-3" style="border-bottom: 1px solid #00000033;">
                    <div class="col-1 text-center m-auto" >
                        <a class="px-2 py-1" @click="$router.go(-1)">
                        Back
                    </a>
                    </div>
                    
                    <p class="px-2 col-11 m-auto" style="font-size:24px">
                        {{subject}}
                    </p>
                </div>
                <p class="pt-4 pl-3">
                    {{content}}
                </p>
            </div>
        </div>
    </div>
</template>
<script>

export default ({
    data: function () {
        return{
            subject:"",
            content:""
        }
    },
    mounted(){
        console.log(this.$route.params.id);
        var items = JSON.parse(localStorage.getItem('messages'));
        for (let index = 0; index < items.length; index++) {
            if (items[index].id==this.$route.params.id) {
                this.subject=items[index].subject;
                this.content=items[index].content;
            }
        }
        console.log(items)
        console.log(this.subject)
        console.log(this.content)
    }
})
</script>

<style scoped>
#msgbox{
    background: white;
    height: 100%;
}
#boxrow{
    justify-content: center;
    display: flex;
    height: 50%;
    align-items: center;
}
#welcome{
    width: 100%;
    border: 1px solid #00000075;
    background: rgb(34, 105, 187);
    border-radius: 10px;
    box-shadow: 6px 8px 20px 10px #00000075;
    text-align: left;
    height: 80vh;
}
#welcome a{
    font-weight: bold;
    color: white;
    font-size: 17px;
    border: 1px solid #00000094;
    background: #ffae21;
    border-radius: 5px;
}
#welcome a:hover {
    text-decoration: none!important;
        box-shadow: 0 0 3px 1px #d9e79d66;
    cursor: pointer;
}
</style>
