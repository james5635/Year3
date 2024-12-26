// document.getElementById("add")?.addEventListener("click", () => {
//   let table = document.querySelector("table");

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
document.addEventListener("DOMContentLoaded", () => {
  const form = document.querySelector("form");
  const tableBody = document.querySelector("table tbody");
  let editingRow: any = null; // Track the row being edited

  form?.addEventListener("submit", (e) => {
    e.preventDefault();

    const formData = new FormData(form);
    const values: any = Array.from(formData.values());

    if (editingRow) {
      // Update the existing row
      const cells = editingRow.querySelectorAll("td");
      values.forEach((value, index) => {
        cells[index].textContent = value;
      });
      editingRow = null;
    } else {
      // Add a new row
      const newRow = document.createElement("tr");

      values.forEach((value) => {
        const td = document.createElement("td");
        td.textContent = value;
        newRow.appendChild(td);
      });

      const actionsTd = document.createElement("td");
      actionsTd.innerHTML = `
              <button class="edit">Edit</button>
              <button class="delete">Delete</button>
          `;
      newRow.appendChild(actionsTd);

      tableBody?.appendChild(newRow);
    }

    form.reset();
  });

  tableBody?.addEventListener("click", (e: any) => {
    if (e.target?.classList.contains("delete")) {
      e.target.closest("tr").remove();
    } else if (e.target.classList.contains("edit")) {
      editingRow = e.target.closest("tr");
      const cells = editingRow.querySelectorAll("td");

      [...cells].slice(0, -1).forEach((cell, index) => {
        const input: any = form?.elements[index];
        if (input) {
          input.value = cell.textContent;
        }
      });
    }
  });
});
