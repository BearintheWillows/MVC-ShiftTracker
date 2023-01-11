/*
 * ATTENTION: The "eval" devtool has been used (maybe by default in mode: "development").
 * This devtool is neither made for production nor for readable output files.
 * It uses "eval()" calls to create a separate source file in the browser devtools.
 * If you are trying to read the output file, select a different devtool (https://webpack.js.org/configuration/devtool/)
 * or disable the default devtool with "devtool: false".
 * If you are looking for production-ready output files, see mode: "production" (https://webpack.js.org/configuration/mode/).
 */
var MYAPP;
/******/ (() => { // webpackBootstrap
/******/ 	"use strict";
/******/ 	var __webpack_modules__ = ({

/***/ "./ClientScripts/shiftService.js":
/*!***************************************!*\
  !*** ./ClientScripts/shiftService.js ***!
  \***************************************/
/***/ ((__unused_webpack_module, exports) => {

eval("\r\nObject.defineProperty(exports, \"__esModule\", ({ value: true }));\r\nclass ShiftService {\r\n    constructor() {\r\n        this.baseUrl = \"https://localhost:44392/api/shifts\";\r\n    }\r\n    getShifts() {\r\n        return fetch(this.baseUrl)\r\n            .then(response => response.json());\r\n    }\r\n}\r\nexports[\"default\"] = ShiftService;\r\n//# sourceMappingURL=shiftService.js.map\n\n//# sourceURL=webpack://MYAPP/./ClientScripts/shiftService.js?");

/***/ }),

/***/ "./ClientScripts/app.ts":
/*!******************************!*\
  !*** ./ClientScripts/app.ts ***!
  \******************************/
/***/ ((__unused_webpack_module, __webpack_exports__, __webpack_require__) => {

eval("__webpack_require__.r(__webpack_exports__);\n/* harmony export */ __webpack_require__.d(__webpack_exports__, {\n/* harmony export */   \"functions\": () => (/* reexport safe */ _functions__WEBPACK_IMPORTED_MODULE_0__.functions)\n/* harmony export */ });\n/* harmony import */ var _functions__WEBPACK_IMPORTED_MODULE_0__ = __webpack_require__(/*! ./functions */ \"./ClientScripts/functions.ts\");\n\r\n\n\n//# sourceURL=webpack://MYAPP/./ClientScripts/app.ts?");

/***/ }),

/***/ "./ClientScripts/functions.ts":
/*!************************************!*\
  !*** ./ClientScripts/functions.ts ***!
  \************************************/
/***/ ((__unused_webpack_module, __webpack_exports__, __webpack_require__) => {

eval("__webpack_require__.r(__webpack_exports__);\n/* harmony export */ __webpack_require__.d(__webpack_exports__, {\n/* harmony export */   \"functions\": () => (/* binding */ functions)\n/* harmony export */ });\n/* harmony import */ var _shiftService_js__WEBPACK_IMPORTED_MODULE_0__ = __webpack_require__(/*! ./shiftService.js */ \"./ClientScripts/shiftService.js\");\n\r\nvar functions;\r\n(function (functions) {\r\n    let shiftService = new _shiftService_js__WEBPACK_IMPORTED_MODULE_0__[\"default\"]();\r\n    document.querySelector(\".addButton\").addEventListener(\"click\", () => {\r\n        console.log(shiftService.getShifts());\r\n    });\r\n})(functions || (functions = {}));\r\n\n\n//# sourceURL=webpack://MYAPP/./ClientScripts/functions.ts?");

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
/******/ 	
/******/ 	// startup
/******/ 	// Load entry module and return exports
/******/ 	// This entry module can't be inlined because the eval devtool is used.
/******/ 	var __webpack_exports__ = __webpack_require__("./ClientScripts/app.ts");
/******/ 	MYAPP = __webpack_exports__;
/******/ 	
/******/ })()
;