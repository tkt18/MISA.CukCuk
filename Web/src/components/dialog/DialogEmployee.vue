<template>
  <BaseDialog width="900" height="650" :title="title" :isShow="isShow">
    <div class="dialog-toolbar">
      <span class="toolbar-button button-add" :class="{ active: isAdd }" @click="btnAddOnClick">
        <span class="toolbar-button-icon button-add-icon"></span>
        <span class="button-text">Thêm</span>
      </span>
      <span class="toolbar-button button-update" :class="{ active: isView }" @click="btnUpdateOnClick">
        <span class="toolbar-button-icon button-update-icon"></span>
        <span class="button-text">Sửa</span>
      </span>
      <span class="toolbar-button button-submit" :class="{ active: !isView }" @click="btnSubmitOnClick">
        <span class="toolbar-button-icon button-submit-icon"></span>
        <span class="button-text">Cất</span>
      </span>
      <span class="toolbar-button button-delete" :class="{ active: !isAdd }" @click="btnDeleteOnClick">
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
              v-model="employee.employeeCode"
              ref="employeeCode"
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
              v-model="employee.email"
            />
          </div>

          <div class="PhoneNumber">
            <label for="PhoneNumber">Số điện thoại <span>(*)</span></label>
            <input
              type="text"
              name="PhoneNumber"
              class="PhoneNumber"
              v-model="employee.phoneNumber"
            />
          </div>

          <div class="FullName">
            <label for="FullName">Học và tên <span>(*)</span></label>
            <input
              type="text"
              name="FullName"
              class="FullName"
              v-model="employee.fullName"
            />
          </div>

          <div>
            <div class="Gender">
              <label for="Gender">Giới tính </label>
              <input
                type="text"
                name="Gender"
                class="Gender"
                v-model="employee.genderName"
              />
            </div>

            <div class="DateOfBirth">
              <label for="DateOfBirth">Ngày sinh </label>
              <input
                type="date"
                name="DateOfBirth"
                class="DateOfBirth"
                v-model="employee.dateOfBirth"
              />
            </div>
          </div>

          <div class="IdentifyNumber">
            <label for="IdentifyNumber">Số CMND <span>(*)</span></label>
            <input
              type="text"
              name="IdentifyNumber"
              class="IdentifyNumber"
              v-model="employee.identifyNumber"
            />
          </div>

          <div class="DateOfIssue">
            <label for="DateOfIssue">Ngày cấp </label>
            <input
              type="date"
              name="DateOfIssue"
              class="DateOfIssue"
              v-model="employee.dateOfIssue"
            />
          </div>

          <div class="PlaceOfIssue">
            <label for="PlaceOfIssue">Nơi cấp CMND </label>
            <input
              type="text"
              name="PlaceOfIssue"
              class="PlaceOfIssue"
              v-model="employee.placeOfIssue"
            />
          </div>

          <div class="Role">
            <label for="Role">Phân quyền <span>(*)</span></label>

            <div class="checkbox">
              <span
                class="check-icon"
                :class="{ checked: isFirstRoleChecked }"
                @click="roleSelect(roles[0].roleId)"
              ></span>
              <span>{{ roles[0].roleName }}</span>
            </div>
            <div class="checkbox">
              <span
                class="check-icon"
                :class="{ checked: !isFirstRoleChecked }"
                @click="roleSelect(roles[1].roleId)"
              ></span>
              <span>{{ roles[1].roleName }}</span>
            </div>
          </div>

          <div class="Status">
            <label for="Status">Trạng thái làm việc <span>(*)</span></label>
            <select
              type="checkbox"
              name="Status"
              class="Status"
              v-model="employee.status"
            >
              <option value="0">Thử việc</option>
              <option value="1">Chính thức</option>
              <option value="2">Nghỉ việc</option>
            </select>
          </div>

          <div class="IsAllowUseSoftware">
            <div class="checkbox">
              <span
                class="check-icon"
                :class="{ checked: employee.isAllowUseSoftware }"
                @click="IsAllowUseSoftwareSelect()"
              ></span>
              <span>Cho phép làm việc với phần mềm CUKCUK </span>
            </div>
          </div>
        </div>
        <div class="form-group-2">
          <div class="avatar">
            <input type="image" ref="avarta" hidden />
            <div class="hint-text">
              Chỉ được upload file <b>.jpg, .jpeg, .png, .gif.</b>
            </div>
            <div class="btn">
              <div class=" btn-select-image">
                <span>...</span>
              </div>
              <div class=" btn-clear-image">
                <span class="icon-x"></span>
              </div>
            </div>
          </div>
        </div>
      </form>
    </div>
  </BaseDialog>
</template>

<script>
import {
  addEmployee,
  employeeDialogTitles,
  updateEmployee,
  viewEmployee,
} from "../../const";
import { eventBus } from "../../eventBus";
import * as axios from "axios";
import BaseDialog from "../base/BaseDialog";
export default {
  name: "DialogEmployee",
  components: {
    BaseDialog,
  },
  async created() {
    const response = await axios.get("https://localhost:44399/api/v1/Roles");
    this.roles = response.data.data.entities;
    console.log(this.roles);

    eventBus.$on("closeDialog", (title) => {
      if (this.title == title) {
        this.isShow = false;
      }
    });
    eventBus.$on("openEmployeeDialog", (action, employee) => {
      this.employee = { ...employee };
      this.employee.dateOfBirth = this.formatDate(this.employee.dateOfBirth);
      this.employee.dateOfIssue = this.formatDate(this.employee.dateOfIssue);
      this.action = action;
      this.isShow = true;
      console.log(this.action, this.employee);
    });
  },
  computed: {
    isFirstRoleChecked: function() {
      if (this.employee.roleId == this.roles[0].roleId) {
        return true;
      }
      return false;
    },
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
  methods: {
      focus: function () {
    this.$refs.employeeCode.focus()
  },
    btnAddOnClick() {
      this.action = addEmployee;
    },
    btnUpdateOnClick() {
      this.action = updateEmployee;
    },
    btnDeleteOnClick() {
      axios({
        method: "delete",
        url: `https://localhost:44399/api/v1/Employees${this.employee.employeeId}`,
        data: this.employee,
      }).then(function(response) {
          console.log(response);
        })
        .catch(function(error) {
          console.log(error);
        });
    },

    async btnSubmitOnClick() {
      var _method = this.isAdd ? "post" : "put";
      var _url = this.isAdd
        ? `https://localhost:44399/api/v1/Employees`
        : `https://localhost:44399/api/v1/Employees${this.employee.employeeId}`;

      axios({
        method: _method,
        url: _url,
        data: this.employee,
      })
        .then(function(response) {
          console.log(response);
        })
        .catch(function(error) {
          console.log(error);
        });
    },
    IsAllowUseSoftwareSelect() {
      this.employee.isAllowUseSoftware = !this.employee.isAllowUseSoftware;
    },
    roleSelect(roleId) {
      this.employee.roleId = roleId;
    },
    formatDate(oldDate) {
      if (oldDate != null && oldDate != "") {
        var date = new Date(oldDate);
        return `${date.getFullYear()}-${
          date.getMonth() < 9
            ? "0" + (date.getMonth() + 1)
            : date.getMonth() + 1
        }-${date.getDate() < 10 ? "0" + date.getDate() : date.getDate()}`;
      }
      return null;
    },
  },
  data: function() {
    return {
      title: employeeDialogTitles,
      isShow: false,
      action: null,
      employee: {
        dateOfBirth: "",
        dateOfIssue: "",
        email: "",
        employeeCode: "",
        employeeId: "",
        fullName: "",
        gender: "",
        genderName: "",
        identifyNumber: "",
        isAllowUseSoftware: "",
        modifiedBy: "",
        modifiedDate: "",
        phoneNumber: "",
        placeOfIssue: "",
        roleId: "",
        status: "",
        statusName: "",
      },
      roles: [
        {
          description: "",
          roleId: "",
          roleName: "",
        },
        {
          description: "",
          roleId: "",
          roleName: "",
        },
      ],
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

  .form-group-1 {
    position: relative;
    float: left;
    width: 80%;
    div {
      width: 100%;
      height: 30px;
    }
    label {
      display: inline-block;
      margin-top: 5px;
      width: 150px;
    }
    label[for="DateOfIssue"],
    label[for="DateOfBirth"] {
      width: 100px;
    }
    label span {
      color: #ff0e00;
    }
    select,
    input {
      display: inline;
      width: 150px;
    }
    input[type="radio"],
    input[type="checkbox"] {
      visibility: hidden;
    }
    div.checkbox {
      display: inline;
      margin-right: 40px;
      span.check-icon {
        cursor: pointer;
        display: inline-block;
        background: url("~@/assets/images/checkbox.png") no-repeat -1px -1px;
        width: 13px;
        height: 13px;
        margin-right: 10px;
      }
      span.check-icon.checked {
        background: url("~@/assets/images/checkbox.png") no-repeat -1px -15px;
        width: 13px;
        height: 13px;
        margin-right: 10px;
      }
    }
    input[type="date"] {
      display: inline;
      width: 188px;
    }

    input.FullName,
    input.PlaceOfIssue {
      width: 560px;
    }
    div.Gender,
    div.IdentifyNumber,
    div.DateOfBirth,
    div.DateOfIssue {
      display: inline;
    }
    div.Status {
      display: inline;
      select {
        width: 200px;
        margin-right: 20px;
      }
    }
    div.IsAllowUseSoftware {
      display: inline-block;
      width: 330px;
    }
    div.Email input,
    div.PhoneNumber input,
    div.Gender input,
    div.IdentifyNumber input {
      width: 250px;
      margin-right: 20px;
    }
  }
  .form-group-2 {
    position: relative;
    float: left;
    width: 18%;
    input[type="image"] {
      visibility: hidden;
    }
    .avatar {
      position: relative;
      background: url("~@/assets/images/avatardefault.png") 50% 0;
      background-size: 2;
      background-repeat: no-repeat;
      height: 160px;
    }
    .hint-text {
      position: relative;
      display: block;
      top: 130px;
      left: 25px;
      width: 120px;
    }
    .btn {
      position: relative;
      top: 65px;
      left: 35px;
      width: 100px;
      display: flex;
      justify-content: space-between;
      align-items: center;
      .btn-select-image {
        background-color: #ffffff;
        width: 45%;
        height: 20px;
        cursor: pointer;
        span {
          margin-left: 40%;
        }
      }
      .btn-select-image:hover {
        border: 1px solid #0474bd;
        margin: -1px;
      }
      .btn-clear-image {
        background-color: #edeeef;
        height: 20px;
        width: 45%;
        cursor: pointer;
        span.icon-x {
          display: inline-block;
          margin: 5px 0 0 20px;
          background: url("~@/assets/images/IconSprite.png") no-repeat -2px -2683px;
          width: 12px;
          height: 12px;
        }
      }
    }
  }
}
</style>
