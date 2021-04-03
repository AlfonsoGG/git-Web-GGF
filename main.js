let ctx = document.getElementById("Charjs").getContext("2d");
let Mychart = new Chart(ctx, {
  type: "doughnut",
  data: {
    labels: ["Felicidad", "Tristesa", "Enojo", "Seriedad"],
    datasets: [
      {
        label: "Num datos",
        data: [10, 9, 15, 20],
        backgroundColor: [
          "rgb(66, 134, 244,0.5)",
          "rgb(23,254,0,0.5)",
          "rgb(255,0,0,0.5)",
          "rgb(251,255,0,0.5)",
        ],
      },
    ],
  },
});
