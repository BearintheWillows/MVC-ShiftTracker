var JS;
/******/ (() => { // webpackBootstrap
/******/ 	"use strict";
/******/ 	var __webpack_modules__ = ({

/***/ "./src/typescript/components/breakForm.ts":
/*!************************************************!*\
  !*** ./src/typescript/components/breakForm.ts ***!
  \************************************************/
/***/ ((__unused_webpack_module, __webpack_exports__, __webpack_require__) => {

__webpack_require__.r(__webpack_exports__);
/* harmony export */ __webpack_require__.d(__webpack_exports__, {
/* harmony export */   "breakForm": () => (/* binding */ breakForm)
/* harmony export */ });
class breakForm {
    breaks = [];
    constructor() {
    }
    displayAllRows() {
        const form = document.getElementById("breakForm");
        form.innerHTML = "";
        form.append(this.createAddBreakButton());
        console.log(this.breaks);
        this.breaks.forEach((b) => {
            console.log(b);
            form.appendChild(this.createRow(b, this.breaks.indexOf(b)));
        });
        document.getElementById("form__btn--submit").addEventListener('click', () => {
            console.log(this.breaks);
        });
    }
    createTimeInput(b, i, timeType) {
        const input = document.createElement("input");
        input.type = "time";
        input.classList.add("form-control");
        input.id = `${timeType}-${i}`;
        if (timeType === "startTime") {
            input.value = b.startTime.toLocaleTimeString([], { hour: "2-digit", minute: "2-digit" });
        }
        else {
            input.value = b.endTime.toLocaleTimeString([], { hour: '2-digit', minute: '2-digit' });
        }
        input.addEventListener('blur', () => {
            this.updateBreak(input.value, i, timeType);
            console.log(input.value);
        });
        return input;
    }
    createAddBreakButton() {
        const button = document.createElement("button");
        button.innerText = "Add Break";
        button.classList.add("btn", "btn-primary");
        button.type = "button";
        button.addEventListener('click', () => {
            this.breaks.push({
                startTime: new Date(0, 0, 0, 0, 0),
                endTime: new Date(0, 0, 0, 0, 0),
                duration: null
            });
            this.displayAllRows();
        });
        return button;
    }
    createRow(b, i) {
        const row = document.createElement("div");
        row.className = "form-group";
        row.id = `breakRow-${i}`;
        let startTime = this.createTimeInput(b, i, "startTime");
        let endTime = this.createTimeInput(b, i, "endTime");
        let removeButton = this.CreateRemoveButton(i);
        row.append(startTime, endTime, removeButton);
        return row;
    }
    CreateRemoveButton(i) {
        const button = document.createElement("button");
        button.innerText = "Remove";
        button.classList.add("removeBreakButton");
        button.type = "button";
        button.addEventListener('click', () => {
            this.breaks.splice(i, 1);
            this.displayAllRows();
        });
        return button;
    }
    formatTime(value) {
        return new Date(value);
    }
    updateBreak(date, i, timeType) {
        if (timeType === "startTime") {
            this.breaks[i].startTime = this.dateFormat(date);
        }
        else {
            this.breaks[i].endTime = this.dateFormat(date);
        }
        this.breaks[i].duration = this.calculateDuration(this.breaks[i].startTime, this.breaks[i].endTime);
        console.log(this.breaks);
    }
    calculateDuration(startTime, endTime) {
        let duration = (endTime.getTime() - startTime.getTime()) / (1000 * 60);
        let hours = Math.floor(duration / 60);
        let minutes = duration % 60;
        return new Date(0, 0, 0, hours, minutes, 0, 0);
    }
    dateFormat(date) {
        let timeArray = date.split(":");
        return new Date(0, 0, 0, parseInt(timeArray[0]), parseInt(timeArray[1]), 0, 0);
    }
}


/***/ })

/******/ 	});
/************************************************************************/
/******/ 	// The module cache
/******/ 	var __webpack_module_cache__ = {};
/******/ 	
/******/ 	// The require function
/******/ 	function __webpack_require__(moduleId) {
/******/ 		// Check if module is in cache
/******/ 		var cachedModule = __webpack_module_cache__[moduleId];
/******/ 		if (cachedModule !== undefined) {
/******/ 			return cachedModule.exports;
/******/ 		}
/******/ 		// Create a new module (and put it into the cache)
/******/ 		var module = __webpack_module_cache__[moduleId] = {
/******/ 			// no module.id needed
/******/ 			// no module.loaded needed
/******/ 			exports: {}
/******/ 		};
/******/ 	
/******/ 		// Execute the module function
/******/ 		__webpack_modules__[moduleId](module, module.exports, __webpack_require__);
/******/ 	
/******/ 		// Return the exports of the module
/******/ 		return module.exports;
/******/ 	}
/******/ 	
/************************************************************************/
/******/ 	/* webpack/runtime/define property getters */
/******/ 	(() => {
/******/ 		// define getter functions for harmony exports
/******/ 		__webpack_require__.d = (exports, definition) => {
/******/ 			for(var key in definition) {
/******/ 				if(__webpack_require__.o(definition, key) && !__webpack_require__.o(exports, key)) {
/******/ 					Object.defineProperty(exports, key, { enumerable: true, get: definition[key] });
/******/ 				}
/******/ 			}
/******/ 		};
/******/ 	})();
/******/ 	
/******/ 	/* webpack/runtime/hasOwnProperty shorthand */
/******/ 	(() => {
/******/ 		__webpack_require__.o = (obj, prop) => (Object.prototype.hasOwnProperty.call(obj, prop))
/******/ 	})();
/******/ 	
/******/ 	/* webpack/runtime/make namespace object */
/******/ 	(() => {
/******/ 		// define __esModule on exports
/******/ 		__webpack_require__.r = (exports) => {
/******/ 			if(typeof Symbol !== 'undefined' && Symbol.toStringTag) {
/******/ 				Object.defineProperty(exports, Symbol.toStringTag, { value: 'Module' });
/******/ 			}
/******/ 			Object.defineProperty(exports, '__esModule', { value: true });
/******/ 		};
/******/ 	})();
/******/ 	
/************************************************************************/
var __webpack_exports__ = {};
// This entry need to be wrapped in an IIFE because it need to be isolated against other modules in the chunk.
(() => {
/*!*********************************!*\
  !*** ./src/typescript/index.ts ***!
  \*********************************/
__webpack_require__.r(__webpack_exports__);
/* harmony import */ var _components_breakForm__WEBPACK_IMPORTED_MODULE_0__ = __webpack_require__(/*! ./components/breakForm */ "./src/typescript/components/breakForm.ts");

const breakFormComponent = new _components_breakForm__WEBPACK_IMPORTED_MODULE_0__.breakForm();
document.addEventListener("DOMContentLoaded", () => {
    breakFormComponent.displayAllRows();
});

})();

JS = __webpack_exports__;
/******/ })()
;
//# sourceMappingURL=data:application/json;charset=utf-8;base64,eyJ2ZXJzaW9uIjozLCJmaWxlIjoiaW5kZXguYnVuZGxlLmpzIiwibWFwcGluZ3MiOiI7Ozs7Ozs7Ozs7Ozs7OztBQUFPO0FBQ1A7QUFDQTtBQUNBO0FBQ0E7QUFDQTtBQUNBO0FBQ0E7QUFDQTtBQUNBO0FBQ0E7QUFDQTtBQUNBLFNBQVM7QUFDVDtBQUNBO0FBQ0EsU0FBUztBQUNUO0FBQ0E7QUFDQTtBQUNBO0FBQ0E7QUFDQSxzQkFBc0IsU0FBUyxHQUFHLEVBQUU7QUFDcEM7QUFDQSwrREFBK0Qsb0NBQW9DO0FBQ25HO0FBQ0E7QUFDQSw2REFBNkQsb0NBQW9DO0FBQ2pHO0FBQ0E7QUFDQTtBQUNBO0FBQ0EsU0FBUztBQUNUO0FBQ0E7QUFDQTtBQUNBO0FBQ0E7QUFDQTtBQUNBO0FBQ0E7QUFDQTtBQUNBO0FBQ0E7QUFDQTtBQUNBLGFBQWE7QUFDYjtBQUNBLFNBQVM7QUFDVDtBQUNBO0FBQ0E7QUFDQTtBQUNBO0FBQ0EsNkJBQTZCLEVBQUU7QUFDL0I7QUFDQTtBQUNBO0FBQ0E7QUFDQTtBQUNBO0FBQ0E7QUFDQTtBQUNBO0FBQ0E7QUFDQTtBQUNBO0FBQ0E7QUFDQTtBQUNBLFNBQVM7QUFDVDtBQUNBO0FBQ0E7QUFDQTtBQUNBO0FBQ0E7QUFDQTtBQUNBO0FBQ0E7QUFDQTtBQUNBO0FBQ0E7QUFDQTtBQUNBO0FBQ0E7QUFDQTtBQUNBO0FBQ0E7QUFDQTtBQUNBO0FBQ0E7QUFDQTtBQUNBO0FBQ0E7QUFDQTtBQUNBOzs7Ozs7O1VDN0ZBO1VBQ0E7O1VBRUE7VUFDQTtVQUNBO1VBQ0E7VUFDQTtVQUNBO1VBQ0E7VUFDQTtVQUNBO1VBQ0E7VUFDQTtVQUNBO1VBQ0E7O1VBRUE7VUFDQTs7VUFFQTtVQUNBO1VBQ0E7Ozs7O1dDdEJBO1dBQ0E7V0FDQTtXQUNBO1dBQ0EseUNBQXlDLHdDQUF3QztXQUNqRjtXQUNBO1dBQ0E7Ozs7O1dDUEE7Ozs7O1dDQUE7V0FDQTtXQUNBO1dBQ0EsdURBQXVELGlCQUFpQjtXQUN4RTtXQUNBLGdEQUFnRCxhQUFhO1dBQzdEOzs7Ozs7Ozs7Ozs7QUNObUQ7QUFDbkQsK0JBQStCLDREQUFTO0FBQ3hDO0FBQ0E7QUFDQSxDQUFDIiwic291cmNlcyI6WyJ3ZWJwYWNrOi8vSlMvLi9zcmMvdHlwZXNjcmlwdC9jb21wb25lbnRzL2JyZWFrRm9ybS50cyIsIndlYnBhY2s6Ly9KUy93ZWJwYWNrL2Jvb3RzdHJhcCIsIndlYnBhY2s6Ly9KUy93ZWJwYWNrL3J1bnRpbWUvZGVmaW5lIHByb3BlcnR5IGdldHRlcnMiLCJ3ZWJwYWNrOi8vSlMvd2VicGFjay9ydW50aW1lL2hhc093blByb3BlcnR5IHNob3J0aGFuZCIsIndlYnBhY2s6Ly9KUy93ZWJwYWNrL3J1bnRpbWUvbWFrZSBuYW1lc3BhY2Ugb2JqZWN0Iiwid2VicGFjazovL0pTLy4vc3JjL3R5cGVzY3JpcHQvaW5kZXgudHMiXSwic291cmNlc0NvbnRlbnQiOlsiZXhwb3J0IGNsYXNzIGJyZWFrRm9ybSB7XHJcbiAgICBicmVha3MgPSBbXTtcclxuICAgIGNvbnN0cnVjdG9yKCkge1xyXG4gICAgfVxyXG4gICAgZGlzcGxheUFsbFJvd3MoKSB7XHJcbiAgICAgICAgY29uc3QgZm9ybSA9IGRvY3VtZW50LmdldEVsZW1lbnRCeUlkKFwiYnJlYWtGb3JtXCIpO1xyXG4gICAgICAgIGZvcm0uaW5uZXJIVE1MID0gXCJcIjtcclxuICAgICAgICBmb3JtLmFwcGVuZCh0aGlzLmNyZWF0ZUFkZEJyZWFrQnV0dG9uKCkpO1xyXG4gICAgICAgIGNvbnNvbGUubG9nKHRoaXMuYnJlYWtzKTtcclxuICAgICAgICB0aGlzLmJyZWFrcy5mb3JFYWNoKChiKSA9PiB7XHJcbiAgICAgICAgICAgIGNvbnNvbGUubG9nKGIpO1xyXG4gICAgICAgICAgICBmb3JtLmFwcGVuZENoaWxkKHRoaXMuY3JlYXRlUm93KGIsIHRoaXMuYnJlYWtzLmluZGV4T2YoYikpKTtcclxuICAgICAgICB9KTtcclxuICAgICAgICBkb2N1bWVudC5nZXRFbGVtZW50QnlJZChcImZvcm1fX2J0bi0tc3VibWl0XCIpLmFkZEV2ZW50TGlzdGVuZXIoJ2NsaWNrJywgKCkgPT4ge1xyXG4gICAgICAgICAgICBjb25zb2xlLmxvZyh0aGlzLmJyZWFrcyk7XHJcbiAgICAgICAgfSk7XHJcbiAgICB9XHJcbiAgICBjcmVhdGVUaW1lSW5wdXQoYiwgaSwgdGltZVR5cGUpIHtcclxuICAgICAgICBjb25zdCBpbnB1dCA9IGRvY3VtZW50LmNyZWF0ZUVsZW1lbnQoXCJpbnB1dFwiKTtcclxuICAgICAgICBpbnB1dC50eXBlID0gXCJ0aW1lXCI7XHJcbiAgICAgICAgaW5wdXQuY2xhc3NMaXN0LmFkZChcImZvcm0tY29udHJvbFwiKTtcclxuICAgICAgICBpbnB1dC5pZCA9IGAke3RpbWVUeXBlfS0ke2l9YDtcclxuICAgICAgICBpZiAodGltZVR5cGUgPT09IFwic3RhcnRUaW1lXCIpIHtcclxuICAgICAgICAgICAgaW5wdXQudmFsdWUgPSBiLnN0YXJ0VGltZS50b0xvY2FsZVRpbWVTdHJpbmcoW10sIHsgaG91cjogXCIyLWRpZ2l0XCIsIG1pbnV0ZTogXCIyLWRpZ2l0XCIgfSk7XHJcbiAgICAgICAgfVxyXG4gICAgICAgIGVsc2Uge1xyXG4gICAgICAgICAgICBpbnB1dC52YWx1ZSA9IGIuZW5kVGltZS50b0xvY2FsZVRpbWVTdHJpbmcoW10sIHsgaG91cjogJzItZGlnaXQnLCBtaW51dGU6ICcyLWRpZ2l0JyB9KTtcclxuICAgICAgICB9XHJcbiAgICAgICAgaW5wdXQuYWRkRXZlbnRMaXN0ZW5lcignYmx1cicsICgpID0+IHtcclxuICAgICAgICAgICAgdGhpcy51cGRhdGVCcmVhayhpbnB1dC52YWx1ZSwgaSwgdGltZVR5cGUpO1xyXG4gICAgICAgICAgICBjb25zb2xlLmxvZyhpbnB1dC52YWx1ZSk7XHJcbiAgICAgICAgfSk7XHJcbiAgICAgICAgcmV0dXJuIGlucHV0O1xyXG4gICAgfVxyXG4gICAgY3JlYXRlQWRkQnJlYWtCdXR0b24oKSB7XHJcbiAgICAgICAgY29uc3QgYnV0dG9uID0gZG9jdW1lbnQuY3JlYXRlRWxlbWVudChcImJ1dHRvblwiKTtcclxuICAgICAgICBidXR0b24uaW5uZXJUZXh0ID0gXCJBZGQgQnJlYWtcIjtcclxuICAgICAgICBidXR0b24uY2xhc3NMaXN0LmFkZChcImJ0blwiLCBcImJ0bi1wcmltYXJ5XCIpO1xyXG4gICAgICAgIGJ1dHRvbi50eXBlID0gXCJidXR0b25cIjtcclxuICAgICAgICBidXR0b24uYWRkRXZlbnRMaXN0ZW5lcignY2xpY2snLCAoKSA9PiB7XHJcbiAgICAgICAgICAgIHRoaXMuYnJlYWtzLnB1c2goe1xyXG4gICAgICAgICAgICAgICAgc3RhcnRUaW1lOiBuZXcgRGF0ZSgwLCAwLCAwLCAwLCAwKSxcclxuICAgICAgICAgICAgICAgIGVuZFRpbWU6IG5ldyBEYXRlKDAsIDAsIDAsIDAsIDApLFxyXG4gICAgICAgICAgICAgICAgZHVyYXRpb246IG51bGxcclxuICAgICAgICAgICAgfSk7XHJcbiAgICAgICAgICAgIHRoaXMuZGlzcGxheUFsbFJvd3MoKTtcclxuICAgICAgICB9KTtcclxuICAgICAgICByZXR1cm4gYnV0dG9uO1xyXG4gICAgfVxyXG4gICAgY3JlYXRlUm93KGIsIGkpIHtcclxuICAgICAgICBjb25zdCByb3cgPSBkb2N1bWVudC5jcmVhdGVFbGVtZW50KFwiZGl2XCIpO1xyXG4gICAgICAgIHJvdy5jbGFzc05hbWUgPSBcImZvcm0tZ3JvdXBcIjtcclxuICAgICAgICByb3cuaWQgPSBgYnJlYWtSb3ctJHtpfWA7XHJcbiAgICAgICAgbGV0IHN0YXJ0VGltZSA9IHRoaXMuY3JlYXRlVGltZUlucHV0KGIsIGksIFwic3RhcnRUaW1lXCIpO1xyXG4gICAgICAgIGxldCBlbmRUaW1lID0gdGhpcy5jcmVhdGVUaW1lSW5wdXQoYiwgaSwgXCJlbmRUaW1lXCIpO1xyXG4gICAgICAgIGxldCByZW1vdmVCdXR0b24gPSB0aGlzLkNyZWF0ZVJlbW92ZUJ1dHRvbihpKTtcclxuICAgICAgICByb3cuYXBwZW5kKHN0YXJ0VGltZSwgZW5kVGltZSwgcmVtb3ZlQnV0dG9uKTtcclxuICAgICAgICByZXR1cm4gcm93O1xyXG4gICAgfVxyXG4gICAgQ3JlYXRlUmVtb3ZlQnV0dG9uKGkpIHtcclxuICAgICAgICBjb25zdCBidXR0b24gPSBkb2N1bWVudC5jcmVhdGVFbGVtZW50KFwiYnV0dG9uXCIpO1xyXG4gICAgICAgIGJ1dHRvbi5pbm5lclRleHQgPSBcIlJlbW92ZVwiO1xyXG4gICAgICAgIGJ1dHRvbi5jbGFzc0xpc3QuYWRkKFwicmVtb3ZlQnJlYWtCdXR0b25cIik7XHJcbiAgICAgICAgYnV0dG9uLnR5cGUgPSBcImJ1dHRvblwiO1xyXG4gICAgICAgIGJ1dHRvbi5hZGRFdmVudExpc3RlbmVyKCdjbGljaycsICgpID0+IHtcclxuICAgICAgICAgICAgdGhpcy5icmVha3Muc3BsaWNlKGksIDEpO1xyXG4gICAgICAgICAgICB0aGlzLmRpc3BsYXlBbGxSb3dzKCk7XHJcbiAgICAgICAgfSk7XHJcbiAgICAgICAgcmV0dXJuIGJ1dHRvbjtcclxuICAgIH1cclxuICAgIGZvcm1hdFRpbWUodmFsdWUpIHtcclxuICAgICAgICByZXR1cm4gbmV3IERhdGUodmFsdWUpO1xyXG4gICAgfVxyXG4gICAgdXBkYXRlQnJlYWsoZGF0ZSwgaSwgdGltZVR5cGUpIHtcclxuICAgICAgICBpZiAodGltZVR5cGUgPT09IFwic3RhcnRUaW1lXCIpIHtcclxuICAgICAgICAgICAgdGhpcy5icmVha3NbaV0uc3RhcnRUaW1lID0gdGhpcy5kYXRlRm9ybWF0KGRhdGUpO1xyXG4gICAgICAgIH1cclxuICAgICAgICBlbHNlIHtcclxuICAgICAgICAgICAgdGhpcy5icmVha3NbaV0uZW5kVGltZSA9IHRoaXMuZGF0ZUZvcm1hdChkYXRlKTtcclxuICAgICAgICB9XHJcbiAgICAgICAgdGhpcy5icmVha3NbaV0uZHVyYXRpb24gPSB0aGlzLmNhbGN1bGF0ZUR1cmF0aW9uKHRoaXMuYnJlYWtzW2ldLnN0YXJ0VGltZSwgdGhpcy5icmVha3NbaV0uZW5kVGltZSk7XHJcbiAgICAgICAgY29uc29sZS5sb2codGhpcy5icmVha3MpO1xyXG4gICAgfVxyXG4gICAgY2FsY3VsYXRlRHVyYXRpb24oc3RhcnRUaW1lLCBlbmRUaW1lKSB7XHJcbiAgICAgICAgbGV0IGR1cmF0aW9uID0gKGVuZFRpbWUuZ2V0VGltZSgpIC0gc3RhcnRUaW1lLmdldFRpbWUoKSkgLyAoMTAwMCAqIDYwKTtcclxuICAgICAgICBsZXQgaG91cnMgPSBNYXRoLmZsb29yKGR1cmF0aW9uIC8gNjApO1xyXG4gICAgICAgIGxldCBtaW51dGVzID0gZHVyYXRpb24gJSA2MDtcclxuICAgICAgICByZXR1cm4gbmV3IERhdGUoMCwgMCwgMCwgaG91cnMsIG1pbnV0ZXMsIDAsIDApO1xyXG4gICAgfVxyXG4gICAgZGF0ZUZvcm1hdChkYXRlKSB7XHJcbiAgICAgICAgbGV0IHRpbWVBcnJheSA9IGRhdGUuc3BsaXQoXCI6XCIpO1xyXG4gICAgICAgIHJldHVybiBuZXcgRGF0ZSgwLCAwLCAwLCBwYXJzZUludCh0aW1lQXJyYXlbMF0pLCBwYXJzZUludCh0aW1lQXJyYXlbMV0pLCAwLCAwKTtcclxuICAgIH1cclxufVxyXG4iLCIvLyBUaGUgbW9kdWxlIGNhY2hlXG52YXIgX193ZWJwYWNrX21vZHVsZV9jYWNoZV9fID0ge307XG5cbi8vIFRoZSByZXF1aXJlIGZ1bmN0aW9uXG5mdW5jdGlvbiBfX3dlYnBhY2tfcmVxdWlyZV9fKG1vZHVsZUlkKSB7XG5cdC8vIENoZWNrIGlmIG1vZHVsZSBpcyBpbiBjYWNoZVxuXHR2YXIgY2FjaGVkTW9kdWxlID0gX193ZWJwYWNrX21vZHVsZV9jYWNoZV9fW21vZHVsZUlkXTtcblx0aWYgKGNhY2hlZE1vZHVsZSAhPT0gdW5kZWZpbmVkKSB7XG5cdFx0cmV0dXJuIGNhY2hlZE1vZHVsZS5leHBvcnRzO1xuXHR9XG5cdC8vIENyZWF0ZSBhIG5ldyBtb2R1bGUgKGFuZCBwdXQgaXQgaW50byB0aGUgY2FjaGUpXG5cdHZhciBtb2R1bGUgPSBfX3dlYnBhY2tfbW9kdWxlX2NhY2hlX19bbW9kdWxlSWRdID0ge1xuXHRcdC8vIG5vIG1vZHVsZS5pZCBuZWVkZWRcblx0XHQvLyBubyBtb2R1bGUubG9hZGVkIG5lZWRlZFxuXHRcdGV4cG9ydHM6IHt9XG5cdH07XG5cblx0Ly8gRXhlY3V0ZSB0aGUgbW9kdWxlIGZ1bmN0aW9uXG5cdF9fd2VicGFja19tb2R1bGVzX19bbW9kdWxlSWRdKG1vZHVsZSwgbW9kdWxlLmV4cG9ydHMsIF9fd2VicGFja19yZXF1aXJlX18pO1xuXG5cdC8vIFJldHVybiB0aGUgZXhwb3J0cyBvZiB0aGUgbW9kdWxlXG5cdHJldHVybiBtb2R1bGUuZXhwb3J0cztcbn1cblxuIiwiLy8gZGVmaW5lIGdldHRlciBmdW5jdGlvbnMgZm9yIGhhcm1vbnkgZXhwb3J0c1xuX193ZWJwYWNrX3JlcXVpcmVfXy5kID0gKGV4cG9ydHMsIGRlZmluaXRpb24pID0+IHtcblx0Zm9yKHZhciBrZXkgaW4gZGVmaW5pdGlvbikge1xuXHRcdGlmKF9fd2VicGFja19yZXF1aXJlX18ubyhkZWZpbml0aW9uLCBrZXkpICYmICFfX3dlYnBhY2tfcmVxdWlyZV9fLm8oZXhwb3J0cywga2V5KSkge1xuXHRcdFx0T2JqZWN0LmRlZmluZVByb3BlcnR5KGV4cG9ydHMsIGtleSwgeyBlbnVtZXJhYmxlOiB0cnVlLCBnZXQ6IGRlZmluaXRpb25ba2V5XSB9KTtcblx0XHR9XG5cdH1cbn07IiwiX193ZWJwYWNrX3JlcXVpcmVfXy5vID0gKG9iaiwgcHJvcCkgPT4gKE9iamVjdC5wcm90b3R5cGUuaGFzT3duUHJvcGVydHkuY2FsbChvYmosIHByb3ApKSIsIi8vIGRlZmluZSBfX2VzTW9kdWxlIG9uIGV4cG9ydHNcbl9fd2VicGFja19yZXF1aXJlX18uciA9IChleHBvcnRzKSA9PiB7XG5cdGlmKHR5cGVvZiBTeW1ib2wgIT09ICd1bmRlZmluZWQnICYmIFN5bWJvbC50b1N0cmluZ1RhZykge1xuXHRcdE9iamVjdC5kZWZpbmVQcm9wZXJ0eShleHBvcnRzLCBTeW1ib2wudG9TdHJpbmdUYWcsIHsgdmFsdWU6ICdNb2R1bGUnIH0pO1xuXHR9XG5cdE9iamVjdC5kZWZpbmVQcm9wZXJ0eShleHBvcnRzLCAnX19lc01vZHVsZScsIHsgdmFsdWU6IHRydWUgfSk7XG59OyIsImltcG9ydCB7IGJyZWFrRm9ybSB9IGZyb20gXCIuL2NvbXBvbmVudHMvYnJlYWtGb3JtXCI7XHJcbmNvbnN0IGJyZWFrRm9ybUNvbXBvbmVudCA9IG5ldyBicmVha0Zvcm0oKTtcclxuZG9jdW1lbnQuYWRkRXZlbnRMaXN0ZW5lcihcIkRPTUNvbnRlbnRMb2FkZWRcIiwgKCkgPT4ge1xyXG4gICAgYnJlYWtGb3JtQ29tcG9uZW50LmRpc3BsYXlBbGxSb3dzKCk7XHJcbn0pO1xyXG4iXSwibmFtZXMiOltdLCJzb3VyY2VSb290IjoiIn0=