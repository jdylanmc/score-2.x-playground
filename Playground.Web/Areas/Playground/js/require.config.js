window.require = window.require || {};
window.require.baseUrl = "/Areas/Playground/js";

window.require.paths                           = window.require.paths || {};
window.require.paths.bootstrap                 = "/Areas/ScoreBootstrapUI/js/Vendor/bootstrap.min";
window.require.paths.matchHeight               = "/Areas/ScoreBootstrapUI/js/Vendor/jquery.matchHeight-min";
window.require.paths.scorebootstrap            = "/Areas/ScoreBootstrapUI/js/BootstrapUI";
window.require.paths.jqueryValidate            = "/Areas/ScoreBootstrapUI/js/Vendor/jquery.validate.1.12.0.min";
window.require.paths.jqueryUnobtrusiveAjax     = "/Areas/ScoreBootstrapUI/js/Vendor/jquery.unobtrusive-ajax.min";
window.require.paths.jqueryValidateUnobtrusive = "/Areas/ScoreBootstrapUI/js/Vendor/jquery.validate.unobtrusive.min";

window.require.shim = window.require.shim || {};
window.require.shim.bootstrap                 = { deps: ["jquery"] };
window.require.shim.matchHeight               = { deps: ["jquery"] };
window.require.shim.jqueryValidate            = { deps: ["jquery"] };
window.require.shim.jqueryUnobtrusiveAjax     = { deps: ["jquery"] };
window.require.shim.jqueryValidateUnobtrusive = { deps: ["jqueryValidate"] };
window.require.shim.scorevalidation           = { deps: ["jqueryUnobtrusiveAjax", "jqueryValidateUnobtrusive"] };
