window.dashboardCharts = {
    renderBar: function (canvasId, labels, data) {
        const ctx = document.getElementById(canvasId);
        if (!ctx) return;
        new Chart(ctx, {
            type: 'bar',
            data: {
                labels: labels,
                datasets: [{
                    label: 'Inmuebles por zona',
                    data: data
                }]
            },
            options: { responsive: true, maintainAspectRatio: false }
        });
    },
    renderPie: function (canvasId, labels, data) {
        const ctx = document.getElementById(canvasId);
        if (!ctx) return;
        new Chart(ctx, {
            type: 'pie',
            data: {
                labels: labels,
                datasets: [{ data: data }]
            },
            options: { responsive: true, maintainAspectRatio: false }
        });
    },
    renderLine: function (canvasId, labels, data) {
        const ctx = document.getElementById(canvasId);
        if (!ctx) return;
        new Chart(ctx, {
            type: 'line',
            data: {
                labels: labels,
                datasets: [{ label: 'Visitas', data: data, fill: false }]
            },
            options: { responsive: true, maintainAspectRatio: false }
        });
    }
};
