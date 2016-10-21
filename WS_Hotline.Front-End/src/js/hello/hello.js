define(["require", "exports", "knockout"], function (require, exports, ko) {
    "use strict";
    var HelloViewModel = (function () {
        function HelloViewModel(language, framework) {
            this.language = ko.observable(language);
            this.framework = ko.observable(framework);
        }
        return HelloViewModel;
    }());
});
//# sourceMappingURL=hello.js.map