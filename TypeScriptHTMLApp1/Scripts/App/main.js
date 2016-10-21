define(["require", "exports", 'knockout'], function (require, exports, ko) {
    "use strict";
    require(["jQuery"], function ($) {
        $(document).ready(function () {
            //instantie le view-model de la page
            ko.applyBindings();
        });
    });
});
//# sourceMappingURL=main.js.map