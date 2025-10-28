document.addEventListener("DOMContentLoaded", () => {
    const tabDonante = document.getElementById("registrar-tab-donante");
    const tabOng = document.getElementById("registrar-tab-ong");
    const formDonante = document.getElementById("registrar-form-donante");
    const formOng = document.getElementById("registrar-form-ong");
  
    const cambiarFormulario = (tipo) => {
      if (tipo === "donante") {
        tabDonante.classList.add("registrar-tab--active");
        tabOng.classList.remove("registrar-tab--active");
        formDonante.classList.add("registrar-form--visible");
        formOng.classList.remove("registrar-form--visible");
      } else {
        tabOng.classList.add("registrar-tab--active");
        tabDonante.classList.remove("registrar-tab--active");
        formOng.classList.add("registrar-form--visible");
        formDonante.classList.remove("registrar-form--visible");
      }
    };
  
    tabDonante.addEventListener("click", () => cambiarFormulario("donante"));
    tabOng.addEventListener("click", () => cambiarFormulario("ong"));
  });
  