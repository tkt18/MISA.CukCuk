<template>
  <BaseDialog width="900" height="650" :title="title" :isShow="isShow">
    <div class="dialog-toolbar">
      <span class="toolbar-button button-add" :class="{ active: isAdd }">
        <span class="toolbar-button-icon button-add-icon"></span>
        <span class="button-text">Thêm</span>
      </span>
      <span class="toolbar-button button-update" :class="{ active: isView }">
        <span class="toolbar-button-icon button-update-icon"></span>
        <span class="button-text">Sửa</span>
      </span>
      <span class="toolbar-button button-submit" :class="{ active: !isView }">
        <span class="toolbar-button-icon button-submit-icon"></span>
        <span class="button-text">Cất</span>
      </span>
      <span class="toolbar-button button-delete" :class="{ active: !isAdd }">
        <span class="toolbar-button-icon button-delete-icon"></span>
        <span class="button-text">Xóa</span>
      </span>
      <span class="toolbar-button button-cancle" :class="{ active: isUpdate }">
        <span class="toolbar-button-icon button-cancle-icon"></span>
        <span class="button-text">Hoãn</span>
      </span>
      <span class="separate"></span>
      <span class="toolbar-button button-help active">
        <span class="toolbar-button-icon button-help-icon"></span>
        <span class="button-text">Giúp</span>
      </span>
      <span class="toolbar-button button-close active">
        <span class="toolbar-button-icon button-close-icon"></span>
        <span class="button-text">Đóng</span>
      </span>
    </div>
    <div class="tabbar">
      <div class="tab-general-information selected">Thông tin chung</div>
    </div>
    <div class="form">
      <form>
        <div class="form-group-1">
          <div class="EmployeeCode">
            <label for="EmployeeCode">Mã nhân viên <span>(*)</span></label>
            <input
              type="text"
              name="EmployeeCode"
              class="EmployeeCode"
              :value="employee.employeeCode"
            />
            <span class="hint-text">
              Dùng làm tên đăng nhập vào hệ thống, có thể sử dụng số điện thoại
              hoặc email cho dễ nhớ.
            </span>
          </div>

          <div class="Email">
            <label for="Email">Email <span>(*)</span></label>
            <input
              type="text"
              name="Email"
              class="Email"
              :value="employee.email"
            />
          </div>

          <div class="PhoneNumber">
            <label for="PhoneNumber">Số điện thoại <span>(*)</span></label>
            <input
              type="text"
              name="PhoneNumber"
              class="PhoneNumber"
              :value="employee.phoneNumber"
            />
          </div>

          <div class="FullName">
            <label for="FullName">Học và tên <span>(*)</span></label>
            <input
              type="text"
              name="FullName"
              class="FullName"
              :value="employee.fullName"
            />
          </div>

          <div class="Gender">
            <label for="Gender">Giới tính </label>
            <input
              type="text"
              name="Gender"
              class="Gender"
              :value="employee.genderName"
            />
          </div>

          <div class="DateOfBirth">
            <label for="DateOfBirth">Ngày sinh </label>
            <input
              type="date"
              name="DateOfBirth"
              class="DateOfBirth"
              :value="employee.dateOfBirth"
            />
          </div>

          <div class="IdentifyNumber">
            <label for="IdentifyNumber">Số CMND <span>(*)</span></label>
            <input
              type="text"
              name="IdentifyNumber"
              class="IdentifyNumber"
              :value="employee.identifyNumber"
            />
          </div>

          <div class="DateOfIssue">
            <label for="DateOfIssue">Ngày cấp </label>
            <input
              type="date"
              name="DateOfIssue"
              class="DateOfIssue"
              :value="employee.dateOfIssue"
            />
          </div>

          <div class="PlaceOfIssue">
            <label for="PlaceOfIssue">Nơi cấp CMND </label>
            <input
              type="text"
              name="PlaceOfIssue"
              class="PlaceOfIssue"
              :value="employee.placeOfIssue"
            />
          </div>

          <div class="Role">
            <label for="Role">Phân quyền <span>(*)</span></label>
            <input
              type="text"
              name="Role"
              class="Role"
              :value="employee.role"
            />
          </div>

          <div class="Status">
            <label for="Status">Trạng thái làm việc <span>(*)</span></label>
            <input
              type="text"
              name="Status"
              class="Status"
              :value="employee.status"
            />
          </div>

          <div class="IsAllowUseSoftware">
            <label for="IsAllowUseSoftware"
              >Cho phép làm việc với phần mềm CUKCUK <span>(*)</span></label
            >
            <input
              type="checkbox"
              name="IsAllowUseSoftware"
              class="IsAllowUseSoftware"
              :value="employee.IsAllowUseSoftware"
            />
          </div>
        </div>
        <div class="form-group-2">
          <div class="avatar">
            <input type="image" hidden />
          </div>
        </div>
      </form>
    </div>
  </BaseDialog>
</template>

<script>
import { addEmployee, employeeDialogTitles, updateEmployee, viewEmployee } from "../../const";
import { eventBus } from "../../eventBus";
import * as axios from "axios";
import BaseDialog from "../base/BaseDialog";
export default {
  name: "DialogEmployee",
  components: {
    BaseDialog,
  },
  async mounted(){
    const response = await axios.get(
      "https://localhost:44399/api/v1/Roles"
    );
    this.Role = response.data.data.entities;
  },
  created() {
    eventBus.$on("closeDialog", (title) => {
      if (this.title == title) {
        this.isShow = false;
      }
    });
    eventBus.$on("openEmployeeDialog", (action, employee) => {
      this.employee = {...employee};
      this.action = action;
      this.isShow = true;
      console.log(this.action, this.employee)
    });
  },
  computed: {
    isAdd: function() {
      if (this.action == addEmployee) {
        return true;
      }
      return false;
    },
    isUpdate: function() {
      if (this.action == updateEmployee) {
        return true;
      }
      return false;
    },
    isView: function() {
      if (this.action == viewEmployee) {
        return true;
      }
      return false;
    },
  },
  data: function() {
    return {
      title: employeeDialogTitles,
      isShow: false,
      action: null,
      employee: {
        EmployeeCode: "",
        Email: "",
        PhoneNumber: "",
        FullName: "",
        Gender: "",
        DateOfBirth: "",
        IdentifyNumber: "",
        DateOfIssue: "",
        PlaceOfIssue: "",
        RoleId: "",
        Status: "",
        IsAllowUseSoftware: "",
      },
      Roles: [{ RoleId: "", Role: "" }],
    };
  },
  
};
</script>

<style lang="scss">
.dialog-toolbar {
  position: absolute;
  top: 21px;
  left: 0;
  height: 22px;
  width: Calc(100% - 10px);
  padding: 5px 0 5px 10px;
  background-color: #edeeef;
  border-bottom: 1px solid #d9d9d9;
  display: flex;
}
.toolbar-button {
  opacity: 0.3;
  width: 60px;
  height: 20px;
  padding: 2px 0 2px 0;
}
.active {
  opacity: 1;
}
.toolbar-button.active:hover {
  background-color: #ffffff;
  border: 1px solid #0071c1;
  margin: -1px;
}

.tabbar {
  position: absolute;
  top: 60px;
  left: 0;
  height: 30px;
  width: Calc(100% - 5px);
  padding-left: 5px;
  background-color: #f2f2f2;
  color: #000;
  display: flex;
  cursor: pointer;
}
.tabbar .selected {
  border-top: 2px solid #0072bc;
  border-left: 1px solid#DDDDDD;
  border-right: 1px solid#DDDDDD;
  background-color: #ffffff;
  color: #0474bd;
}
.tab-general-information {
  width: fit-content;
  padding: 5px 10px 0 10px;
}
.form {
  position: absolute;
  top: 100px;
  width: 100%;
  padding: 5px;
  text-align: left;
}
.form-group-1 {
  width: 80%;
  display: flex;
  flex-wrap: wrap;
}
.form-group-1 div {
  width: 100%;
}
.form-group-1 label {
  margin-top: 5px;
  display: inline;
  width: 150px;
  //   float: left;
}
.form-group-1 label span {
  color: #ff0e00;
}
input[type="text"] {
  display: inline;
  width: 150px;
}
input.Email,
input.PhoneNumber {
  width: 415px;
}
input.FullName {
  width: 500px;
}
div.Gender {
  display: inline;
}
</style>
