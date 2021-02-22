<template>
  <BaseDialog>
    <div class="message">
      {{ message }}
    </div>
  </BaseDialog>
</template>

<script>
import BaseDialog from "../base/BaseDialog";
export default {
  name: "DialogAlert",
  component: {
    BaseDialog,
  },
  data: function() {
    return {
      isShow: false,
      message: "",
    };
  },
};
</script>

<style></style>
