<template>
  <div class="base-dialog" :style="style">
    <div class="background"></div>
    <div class="dialog" :style="{ width: width + 'px', height: height + 'px' }">
      <div class="title-bar">
        <div class="title">
          <p class="title-name">{{ title }}</p>
        </div>
        <div class="close-button" @click="CloseDialogOnClick"></div>
      </div>
      <slot></slot>
    </div>
  </div>
</template>
<script>
import { closeDialog } from '../../const';
export default {
  name: "BaseDialog",
  props: {
    title: String,
    width: String,
    height: String,
    isShow: Boolean
  },
  computed: {
    style : function() {
        return this.isShow ? {display:"unset"} : {display:"none"}
    } 
  },
  methods: {
    CloseDialogOnClick: function() {
      window.eventBus.$emit(closeDialog, this.title)
    }
  },
};
</script>
<style lang="scss">
.base-dialog {
  position: absolute;
  top: 0;
  left: 0;
  width: 100vw;
  height: 100vh;
  z-index: 2 !important;
}
.background {
  width: 100%;
  height: 100%;
  background-color: rgba(10, 10, 10, 0.4) !important;
}
.dialog {
  position: absolute;
  top: 50%;
  left: 50%;
  transform: translate(-50%, -50%);
  background-color: white;
  padding: 2px;
  border-radius: 4px;
  border: 5px solid #0973b9;
}
.title-bar {
  position: absolute;
  top: -4px;
  left: -4px;
  width: Calc(100% + 8px);
  height: 25px;
  background-color: #0973b9;
  color: #ffffff;
  border: 0;
}
.title-bar .title {
  position: absolute;
  left: 5px;
  top: 4px;
  font-size: 13px;
}
.close-button {
  position: absolute;
  right: 5px;
  top: 4px;
  width: 16px;
  height: 16px;
  background: url("../../assets/images/tool-sprites.png") no-repeat 0 0;
  cursor: pointer;
}
</style>
