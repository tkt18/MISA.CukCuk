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
      <span class="btn" @click="btnYesOnClick">Đồng ý</span>
      <span class="btn" @click="btnNoOnClick">Hủy</span>
    </div>
  </BaseDialog>
</template>

<script>
import BaseDialog from "../base/BaseDialog";
import { alertDialogTitle } from "../../const";
import { eventBus } from "../../eventBus";
export default {
  name: "DialogVertify",
  components: {
    BaseDialog,
  },
  computed: {},
  methods: {
    btnYesOnClick: function() {
      eventBus.$emit("verified", this.id);
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
      title: alertDialogTitle,
      isShow: true,
      messages: "",
      id: "",
    };
  },
  created() {
    eventBus.$on("closeDialog", (title) => {
      if (this.title == title) {
        this.isShow = false;
      }
      eventBus.$on("openDialogVerify", (employeeId, fullName) => {
        console.log("receive");
        this.messages = `Xác nhận xóa nhân viên ${fullName}`;
        this.id = employeeId;
        this.isShow = true;
      });
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
    width: 60px;
    height: 40px;
    border: 1px solid #5ab4ec;
    padding: 5px 10px;
  }
  .btn:hover {
    background-color: #3ab4ec;
  }
}
</style>
