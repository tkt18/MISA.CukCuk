<template>
  <div class="content-body">
    <div class="header-content">
      <div class="title">Danh sách</div>
      <span class="arrow-icon"></span>
      <div class="subtitle">nhân viên</div>
      <div class="content-feature">
        <div class="filter-left">
          <label for="status" class="filter-label">Lọc nhanh</label>
          <select
            id="status"
            name="status"
            class="m-control"
            @change="loadData($event)"
          >
            <option value="3">Tất cả</option>
            <option value="0">Thử việc</option>
            <option value="1">Chính thức</option>
            <option value="2">Nghỉ việc</option>
          </select>
        </div>
        <div class="filter-right">
          <button id="btnFeedback" class="m-second-button m-btn-back">
            Quay lại thiết lập ban đầu
          </button>
          <button id="btnFeedback" class="m-second-button m-btn-feedback">
            Phản hồi
          </button>
        </div>
      </div>
    </div>
    <div class="sheet">
      <div class="toolbar">
        <span class="toolbar-button button-add active" @click="btnAddOnClick">
          <span class="toolbar-button-icon button-add-icon"></span>
          <span class="button-text">Thêm</span>
        </span>
        <span
          class="toolbar-button button-submit active"
          @click="btnViewOnClick"
        >
          <span class="toolbar-button-icon button-view-icon"></span>
          <span class="button-text">Xem</span>
        </span>
        <span
          class="toolbar-button button-update active"
          @click="btnUpdateOnClick"
        >
          <span class="toolbar-button-icon button-update-icon"></span>
          <span class="button-text">Sửa</span>
        </span>
        <span
          class="toolbar-button button-delete active"
          @click="btnDeleteOnClick"
        >
          <span class="toolbar-button-icon button-delete-icon"></span>
          <span class="button-text">Xóa</span>
        </span>
        <span class="separate"></span>
        <span
          class="toolbar-button button-refresh active"
          @click="btnRefreshOnClick"
        >
          <span class="toolbar-button-icon button-refresh-icon"></span>
          <span class="button-text">Nạp</span>
        </span>
      </div>
      <div
        class="grid grid-employee el-table el-table--fit el-table--scrollable-y el-table--enable-row-hover el-table--enable-row-transition"
      >
        <table
          id="tbListData"
          cellspacing="0"
          cellpadding="0"
          border="0"
          class="el-table__body"
          style="min-width: 100%"
        >
          <thead>
            <tr class="el-table__row">
              <th colspan="1" rowspan="1" fieldName="EmployeeCode">
                <div class="cell EmployeeCode">Tên đăng nhập</div>
              </th>
              <th colspan="1" rowspan="1" fieldName="FullName">
                <div class="cell FullName">Họ và tên</div>
              </th>
              <th colspan="1" rowspan="1" fieldName="PhoneNumber">
                <div class="cell PhoneNumber">Điện thoại</div>
              </th>
              <th
                colspan="1"
                rowspan="1"
                fieldName="DateOfBirth"
                formatType="ddmmyyyy"
                style="text-align: center"
              >
                <div class="cell DateOfBirth">Ngày sinh</div>
              </th>
              <th colspan="1" rowspan="1" fieldName="GenderName">
                <div class="cell GenderName">Giới tính</div>
              </th>

              <th
                colspan="1"
                rowspan="1"
                class="Status"
                fieldName="WorkStatusName"
              >
                <div class="cell WorkStatusName">Tình trạng công việc</div>
              </th>
            </tr>
          </thead>
          <tbody>
            <tr
              class="el-table__row"
              v-for="employee in employees"
              :key="employee.employeeId"
              :class="{ selectedRow: isSelectedRow(employee.employeeId) }"
              @click="selectEmployee(employee)"
              @dblclick="rowOnClick(employee)"
            >
              <td>
                <div class="cell EmployeeCode">{{ employee.employeeCode }}</div>
              </td>
              <td>
                <div class="cell FullName">{{ employee.fullName }}</div>
              </td>
              <td>
                <div class="cell PhoneNumber">{{ employee.phoneNumber }}</div>
              </td>
              <td>
                <div class="cell DateOfBirth">
                  {{ dOb(employee.dateOfBirth) }}
                </div>
              </td>
              <td>
                <div class="cell GenderName">{{ employee.genderName }}</div>
              </td>

              <td>
                <div class="cell WorkStatusName">
                  {{ employee.statusName }}
                </div>
              </td>
            </tr>
          </tbody>
        </table>
      </div>
      <div class="paging-bar">
        <div class="paging-option">
          <div class="btn-select-page m-btn-firstpage"></div>
          <div class="btn-select-page m-btn-prev-page"></div>
          <div class="separate"></div>
          <div class="select-page">
            Trang
            <input
              style="width:50px;height:20px;padding:0;margin:0"
              type="text"
              value="1"
            />
            trên 1
          </div>
          <div class="separate"></div>
          <div class="btn-select-page m-btn-next-page"></div>
          <div class="btn-select-page m-btn-lastpage"></div>
          <div class="separate"></div>
          <div class="btn-select-page m-btn-refresh"></div>
          <div class="separate"></div>
        </div>
        <div class="paging-record-option">
          <select>
            <option value="500">500</option>
          </select>
        </div>
        <div class="paging-record-info">
          Hiển thị 1-{{ numberOfEmployees }} trên {{ numberOfEmployees }} kết
          quả
        </div>
      </div>
    </div>
  </div>
</template>
<script>
import * as axios from "axios";
import { addEmployee, updateEmployee, viewEmployee, verified, openDialogVerify, openEmployeeDialog } from "../../../const";
export default {
  name: "Employees",
  computed: {
    numberOfEmployees: function() {
      return this.employees.length;
    },
  },

  methods: {
    async loadData(event) {
      var res = await axios.get(
        `https://localhost:44399/api/v2/Employees?status=${event.target.value}`
      );
      this.employees = res.data.employees;
      this.selectedEmployee = this.employees[0];
    },
    selectEmployee(employee) {
      this.selectedEmployee = { ...employee };
    },
    btnAddOnClick() {
      window.eventBus.$emit(openEmployeeDialog, addEmployee, this.newEmployee);
    },
    btnViewOnClick() {
      window.eventBus.$emit(openEmployeeDialog, viewEmployee, this.selectedEmployee);
    },
    btnUpdateOnClick() {
      window.eventBus.$emit(
        openEmployeeDialog,
        updateEmployee,
        this.selectedEmployee
      );
    },
    btnDeleteOnClick() {
      window.eventBus.$emit(
        openDialogVerify,
        this.selectedEmployee.employeeId,
        this.selectedEmployee.fullName
      );
    },
    async btnRefreshOnClick() {
      const response = await axios.get(
        "https://localhost:44399/api/v1/Employees"
      );
      this.employees = response.data.data.entities;
      this.selectedEmployee = this.employees[0];
    },
    rowOnClick(employee) {
      this.selectEmployee(employee);
      window.eventBus.$emit(openEmployeeDialog, viewEmployee, employee);
    },
    // closePopup(value) {
    //   this.isHideParent = value;
    // },
    cancelLoading() {
      return false;
    },
    dOb: function(_date) {
      if (_date == null) return null;
      var date = new Date(_date);
      return `${date.getDate() < 10 ? "0" + date.getDate() : date.getDate()}/${
        date.getMonth() < 9 ? "0" + (date.getMonth() + 1) : date.getMonth() + 1
      }/${date.getFullYear()}`;
    },
    isSelectedRow: function(id) {
      if (id == this.selectedEmployee.employeeId) return true;
      return false;
    },
  },

  data() {
    return {
      selectedEmployee: {},
      date: null,
      employees: [],
      newEmployee: {
        dateOfBirth: "",
        dateOfIssue: "",
        email: "",
        employeeCode: "",
        employeeId: "",
        fullName: "",
        gender: "",
        genderName: "",
        identifyNumber: "",
        isAllowUseSoftware: false,
        modifiedBy: "",
        modifiedDate: "",
        phoneNumber: "",
        placeOfIssue: "",
        roleId: "",
        status: "",
        statusName: "",
      },
    };
  },
  async created() {
    window.eventBus.$on(verified, (id) => {
      axios({
        method: "delete",
        url: `https://localhost:44399/api/v1/Employees/${id}`,
        data: this.employee,
      })
        .then((response) => {
          console.log(response);
          this.btnRefreshOnClick();
        })
        .catch(function(error) {
          console.log(error);
        });
    });
    this.isLoading = true;
    const response = await axios.get(
      "https://localhost:44399/api/v1/Employees"
    );
    this.employees = response.data.data.entities;
    this.selectedEmployee = this.employees[0];
  },
};
</script>

<style lang="scss" scoped>
.m-control {
  padding: 5px;
  max-height: 25px;
  max-width: 120px;
}
.filter-label {
  min-width: 60px;
  padding: 5px 0;
}
.content-feature {
  display: flex;
  justify-content: space-between;
  max-width: calc(100% - 230px);
}
.filter-right {
  position: relative;
  left: 25px;
  display: flex;
  justify-content: space-between;
}
.filter-left {
  display: inline-flex;
  width: 300px;
  select {
    min-width: 20px;
  }
}
.filter-left select {
  margin-left: 10px;
  margin-right: 10px;
}
.sheet {
  width: calc(100% - 20px);
  padding: 0 10px;
}
.EmployeeCode {
  width: 200px;
}
.FullName {
  width: 500px;
}
.PhoneNumber {
  width: 200px;
}
.GenderName {
  width: 171px;
}
.DateOfBirth {
  width: 200px;
}
.WorkStatusName {
  width: 183px;
}
.select-page {
  display: inline;
  width: 150px;
  height: 20px;
  padding: 0px;
  margin: 0px;
  input {
    text-align: center;
    display: inline;
  }
}
.selectedRow {
  background-color: #acd0e6 !important;
}
</style>
