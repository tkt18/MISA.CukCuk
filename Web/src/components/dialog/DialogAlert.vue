<template>
  <BaseDialog width="300" height="150" :title="title" :isShow="isShow">
    <div class="message">
      <div v-for="(message, index) in messages" :key="index">
        {{ message }}
      </div>
    </div>
    <div class="button">
      <span class="btn-yes" @click="btnYesOnClick">Đồng ý</span>
    </div>
  </BaseDialog>
</template>

<script>
import BaseDialog from "../base/BaseDialog";
import { alertDialogTitle,closeDialog,openDialogAlert } from "../../const";
export default {
  name: "DialogAlert",
  components: {
    BaseDialog,
  },
  computed: {},
  methods: {
    btnYesOnClick: function() {
      this.isShow = false;
      this.messages = null;
    },
  },
  data: function() {
    return {
      title: alertDialogTitle,
      type: "",
      isShow: false,
      messages: [],
    };
  },
  created() {
    window.eventBus.$on(closeDialog, (title) => {
      if (this.title == title) {
        this.isShow = false;
      }
    });
    window.eventBus.$on(openDialogAlert, messages => {
        console.log(messages);
        this.messages = messages;
        this.isShow = true;
      });
  },
};
</script>

<style lang="scss">
.message{
  margin-top: 20px;
  display: flex;
  flex-direction: column;
  align-items: center;
  justify-content: center;
  height: 100px;
  div{
    padding: 2px 0;
  }
}
.button {
  position: absolute;
  bottom: 10px;
  right: 10px;
  .btn-yes {
    width: 60px;
    height: 40px;
    border: 1px solid #5ab4ec;
    padding: 5px 10px;
    cursor: pointer;
  }
  .btn-yes:hover {
    background-color: #3ab4ec;
  }
}
</style>
