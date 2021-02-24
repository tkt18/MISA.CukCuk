<template>
  <BaseDialog
    class="alert"
    width="300"
    height="150"
    :title="title"
    :isShow="isShow"
  >
    <div class="message-verify">
      {{ messages }}
    </div>
    <div class="button">
      <span class="btn yes" @click="btnYesOnClick">Đồng ý</span>
      <span class="btn no" @click="btnNoOnClick">Hủy</span>
    </div>
  </BaseDialog>
</template>

<script>
import BaseDialog from "../base/BaseDialog";
import { verifyDialogTitle, verified, openDialogVerify, closeDialog } from "../../const";
export default {
  name: "DialogVertify",
  components: {
    BaseDialog,
  },
  computed: {},
  methods: {
    btnYesOnClick: function() {
      window.eventBus.$emit(verified, this.id);
      this.isShow = false;
      this.messages = null;
    },
    btnNoOnClick: function() {
      this.isShow = false;
      this.messages = null;
    },
  },
  data: function() {
    return {
      title: verifyDialogTitle,
      isShow: false,
      messages: "",
      id: "",
    };
  },
  created() {
    console.log("Verify Dialog created");
    window.eventBus.$on(closeDialog, (title) => {
      if (this.title == title) {
        this.isShow = false;
      }
    });
    window.eventBus.$on(openDialogVerify, (employeeId, fullName) => {
        console.log(employeeId, fullName);
        this.messages = `Xác nhận xóa nhân viên ${fullName}`;
        this.id = employeeId;
        this.isShow = true;
      });
  },
};
</script>

<style lang="scss">
.alert {
  z-index: 3;
}
.message-verify {
  margin-top: 65px;
}
.button {
  position: absolute;
  bottom: 10px;
  right: 10px;
  .btn {
    display: inline-block;
    width: 50px;
    height: 15px;
    border: 1px solid #5ab4ec;
    padding: 5px 10px;
    margin-left: 5px;
    cursor: pointer;
  }
  .btn.yes:hover {
    background-color: #3ab4ec;
  }
  .btn.no:hover{
    background-color: #ec3a3a;
    color: #fff;
  }
}
</style>
