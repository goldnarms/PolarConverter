var PolarConverter;
(function (PolarConverter) {
    "use strict";
    (function (fileType) {
        fileType[fileType["gpx"] = 0] = "gpx";
        fileType[fileType["hrm"] = 1] = "hrm";
        fileType[fileType["xml"] = 2] = "xml";
    })(PolarConverter.fileType || (PolarConverter.fileType = {}));
    var fileType = PolarConverter.fileType;
})(PolarConverter || (PolarConverter = {}));
//# sourceMappingURL=fileTypeEnum.js.map