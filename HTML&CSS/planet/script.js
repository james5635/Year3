// document.getElementById("add")?.addEventListener("click", () => {
//   let table = document.querySelector("table");
var __spreadArray = (this && this.__spreadArray) || function (to, from, pack) {
    if (pack || arguments.length === 2) for (var i = 0, l = from.length, ar; i < l; i++) {
        if (ar || !(i in from)) {
            if (!ar) ar = Array.prototype.slice.call(from, 0, i);
            ar[i] = from[i];
        }
    }
    return to.concat(ar || Array.prototype.slice.call(from));
};
//   let Id = (<HTMLInputElement>document.getElementById("Id"))?.value;
//   let Name = (<HTMLInputElement>document.getElementById("Name"))?.value;
//   let Mass = (<HTMLInputElement>document.getElementById("Mass"))?.value;
//   // console.log(Id, Name, Mass);
//   // console.log(document.querySelectorAll("table tr td")[0])
//   let newTr = document.createElement("tr");
//   let newTdId = document.createElement("td");
//   newTdId.innerHTML = Id;
//   let newTdName = document.createElement("td");
//   newTdName.innerHTML = Name;
//   let newTdMass = document.createElement("td");
//   newTdMass.innerHTML = Mass;
//   newTr.appendChild(newTdId);
//   newTr.appendChild(newTdName);
//   newTr.appendChild(newTdMass);
//   table?.appendChild(newTr);
// });
document.addEventListener("DOMContentLoaded", function () {
    var form = document.querySelector("form");
    var tableBody = document.querySelector("table tbody");
    var editingRow = null; // Track the row being edited
    form === null || form === void 0 ? void 0 : form.addEventListener("submit", function (e) {
        e.preventDefault();
        var formData = new FormData(form);
        var values = Array.from(formData.values());
        if (editingRow) {
            // Update the existing row
            var cells_1 = editingRow.querySelectorAll("td");
            values.forEach(function (value, index) {
                cells_1[index].textContent = value;
            });
            editingRow = null;
        }
        else {
            // Add a new row
            var newRow_1 = document.createElement("tr");
            values.forEach(function (value) {
                var td = document.createElement("td");
                td.textContent = value;
                newRow_1.appendChild(td);
            });
            var actionsTd = document.createElement("td");
            actionsTd.innerHTML = "\n              <button class=\"edit\">Edit</button>\n              <button class=\"delete\">Delete</button>\n          ";
            newRow_1.appendChild(actionsTd);
            tableBody === null || tableBody === void 0 ? void 0 : tableBody.appendChild(newRow_1);
        }
        form.reset();
    });
    tableBody === null || tableBody === void 0 ? void 0 : tableBody.addEventListener("click", function (e) {
        var _a;
        if ((_a = e.target) === null || _a === void 0 ? void 0 : _a.classList.contains("delete")) {
            e.target.closest("tr").remove();
        }
        else if (e.target.classList.contains("edit")) {
            editingRow = e.target.closest("tr");
            var cells = editingRow.querySelectorAll("td");
            __spreadArray([], cells, true).slice(0, -1).forEach(function (cell, index) {
                var input = form === null || form === void 0 ? void 0 : form.elements[index];
                if (input) {
                    input.value = cell.textContent;
                }
            });
        }
    });
});
