document.addEventListener("DOMContentLoaded", function () {
    const tabButtons = document.querySelectorAll("#balance-manager .balance-tab-btn");
    const tabPanels = document.querySelectorAll("#balance-manager .balance-tab-panel");

    tabButtons.forEach((btn) => {
        btn.addEventListener("click", function () {
            tabButtons.forEach((b) => b.classList.remove("active"));
            this.classList.add("active");

            tabPanels.forEach((panel) => panel.classList.remove("active"));
            const targetTab = document.getElementById(this.dataset.tab);
            targetTab.classList.add("active");
        });
    });
});
