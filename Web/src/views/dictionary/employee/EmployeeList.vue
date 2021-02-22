<template>
  <div class="content-body">
    <!-- <BaseLoading :showLoading="isLoading"/> -->
    <div class="header-content">
      <div class="title">Danh sách</div>
      <span class="arrow-icon"></span>
      <div class="subtitle">nhân viên</div>
      <div class="content-feature">
        <div class="filter-left">
          <label for="status" class="filter-label">Lọc nhanh</label>
          <select id="status" name="status" class="m-control">
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
        <span class="toolbar-button button-refresh active">
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
            <option value="25">25</option>
            <option value="50">50</option>
            <option value="100">100</option>
          </select>
        </div>
        <div class="paging-record-info">Hiển thị 1-10 trên 1000 kết quả</div>
      </div>
    </div>

    <!-- <Details @closePopup="closePopup" :isHide="isHideParent" /> -->
  </div>
</template>
<script>
import * as axios from "axios";
import { eventBus } from "../../../eventBus";
import { addEmployee, updateEmployee, viewEmployee } from "../../../const";
export default {
  name: "Employees",
  components: {
    // Details,
  },
  methods: {
    selectEmployee(employee) {
      this.selectedEmployee = { ...employee };
    },
    btnAddOnClick() {
      eventBus.$emit("openEmployeeDialog", addEmployee);
    },
    btnViewOnClick() {
      eventBus.$emit("openEmployeeDialog", viewEmployee, this.selectedEmployee);
    },
    btnUpdateOnClick() {
      eventBus.$emit(
        "openEmployeeDialog",
        updateEmployee,
        this.selectedEmployee
      );
    },
    async btnDeleteOnClick() {
      const res = await axios.delete(
        `https://localhost:44399/api/v1/Employees/${this.selectedEmployee.employeeId}`
      );
      await this.btnRefreshOnClick();
      console.log(res);
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
      eventBus.$emit("openEmployeeDialog", viewEmployee, employee);
    },
    // closePopup(value) {
    //   this.isHideParent = value;
    // },
    cancelLoading() {
      return false;
    },
    dOb: function(_date) {
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
      isLoading: false,
      canCancel: false,
      onCancel: this.cancelLoading,
      isHideParent: true,
      selectedEmployee: {},
      date: null,
      employees: [],
    };
  },
  async created() {
    this.isLoading = true;
    const response = await axios.get(
      "https://localhost:44399/api/v1/Employees"
    );
    this.employees = response.data.data.entities;
    this.selectedEmployee = this.employees[0];
    console.log(this.selectedEmployee);
    this.isLoading = false;
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
  padding: 0 5px;
}
.selectedRow {
  background-color: #acd0e6 !important;
}
</style>
