
function getShifts(): Promise<IShift[]> {
        return fetch("https://localhost:44392/api/shifts")
            .then(response => response.json()
            )}

document.getElementsByClassName("getShiftBtn")[0].addEventListener("click", () => {
    getShifts().then(shifts => {
        console.log(shifts);
    })
})
