using JetBrains.Annotations;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using MetadataExtractor.Formats.Tiff;

namespace MetadataExtractor.Formats.Exif.Makernotes
{
    /// <summary>Describes tags specific to PhaseOne cameras.</summary>
    /// <remarks>Using information from https://www.sno.phy.queensu.ca/~phil/exiftool/TagNames/PhaseOne.html </remarks>
    /// <author>Alex Pavloff, adapted from Drew Noakes https://drewnoakes.com</author>
    [SuppressMessage("ReSharper", "MemberCanBePrivate.Global")]
    public class PhaseOneMakernoteDirectory : Directory
    {
        public const int TagCameraOrientation = 0x0100;
        public const int TagSerialNumber = 0x0102;
        public const int TagISO = 0x0105;
        public const int TagColorMatrix1 = 0x0106;
        public const int TagWB_RGBLevels = 0x0107;
        public const int TagSensorWidth = 0x0108;
        public const int TagSensorHeight = 0x0109;
        public const int TagSensorLeftMargin = 0x010a;
        public const int TagSensorTopMargin = 0x010b;
        public const int TagImageWidth = 0x010c;
        public const int TagImageHeight = 0x010d;
        public const int TagRawFormat = 0x010e;
        public const int TagRawData = 0x010f;
        public const int TagSensorCalibration = 0x0110;
        public const int TagDateTimeOriginal = 0x0112;
        public const int TagImageNumber = 0x0113;
        public const int TagSoftware = 0x0203;
        public const int TagSystem = 0x0204;
        public const int TagSensorTemperature = 0x0210;
        public const int TagSensorTemperature2 = 0x0211;
        public const int TagStripOffsets = 0x021C;
        public const int TagBlackLevel = 0x021D;
        public const int TagSplitColumn = 0x0222;
        public const int TagBlackLevelData = 0x0223;
        public const int TagColorMatrix2 = 0x0226;
        public const int TagAFAdjustment = 0x0267;
        public const int TagFirmwareVersions = 0x0301;
        public const int TagShutterSpeedValue = 0x0400;
        public const int TagApertureValue = 0x0401;
        public const int TagExposureCompensation = 0x0402;
        public const int TagFocalLength = 0x0403;
        public const int TagCameraModel = 0x0410;
        public const int TagLensModel = 0x0412;
        public const int TagMaxApertureValue = 0x0414;
        public const int TagMinApertureValue = 0x0415;
        public const int TagViewfinder = 0x0455;

        private static readonly Dictionary<int, string> _tagNameMap = new Dictionary<int, string>
        {
            { TagCameraOrientation, "Camera Orientation" },
            { TagSerialNumber, "Serial Number" },
            { TagISO, "ISO" },
            { TagColorMatrix1, "Color Matrix 1" },
            { TagWB_RGBLevels, "WB_RGB Levels" },
            { TagSensorWidth, "Sensor Width" },
            { TagSensorHeight, "Sensor Height" },
            { TagSensorLeftMargin, "Sensor Left Margin" },
            { TagSensorTopMargin, "Sensor Top Margin" },
            { TagImageWidth, "Sensor Image Width" },
            { TagImageHeight, "Sensor Image Height" },
            { TagRawFormat, "Raw Format" },
            { TagRawData, "Raw Data" },
            { TagSensorCalibration, "Sensor Calibration" },
            { TagDateTimeOriginal, "Date/Time Original" },
            { TagImageNumber, "Image Number" },
            { TagSoftware, "Software" },
            { TagSystem, "System" },
            { TagSensorTemperature, "Sensor Temperature" },
            { TagSensorTemperature2, "Sensor Temperature 2" },
            { TagStripOffsets, "Strip Offsets" },
            { TagBlackLevel, "Black Level" },
            { TagSplitColumn, "Split Column" },
            { TagBlackLevelData, "Black Level Data" },
            { TagColorMatrix2, "Color Matrix 2" },
            { TagAFAdjustment, "AF Adjustment" },
            { TagFirmwareVersions, "Firmware Versions" },
            { TagShutterSpeedValue, "Shutter Speed Value" },
            { TagApertureValue, "Aperture Value" },
            { TagExposureCompensation, "Exposure Compensation" },
            { TagFocalLength, "Focal Length" },
            { TagCameraModel, "Camera Model" },
            { TagLensModel, "Lens Model" },
            { TagMaxApertureValue, "Max Aperture Value" },
            { TagMinApertureValue, "Min Aperture Value" },
            { TagViewfinder, "Viewfinder" },
        };


        public static TiffDataFormat Format(int tag)
        {
            switch (tag)
            {
                case TagWB_RGBLevels:
                case TagColorMatrix1:
                case TagSensorTemperature:
                case TagSensorTemperature2:
                case TagBlackLevelData:
                case TagColorMatrix2:
                case TagAFAdjustment:
                case TagShutterSpeedValue:
                case TagApertureValue:
                case TagExposureCompensation:
                case TagFocalLength:
                case TagMaxApertureValue:
                case TagMinApertureValue:
                    return TiffDataFormat.Single;
                case TagSerialNumber:
                case TagSoftware:
                case TagSystem:
                case TagFirmwareVersions:
                case TagCameraModel:
                case TagLensModel:
                case TagViewfinder:
                    return TiffDataFormat.String;
                case TagDateTimeOriginal:
                    return TiffDataFormat.Int32U;
                default:
                    return TiffDataFormat.Int32S;
            }
        }

        public PhaseOneMakernoteDirectory()
        {
            SetDescriptor(new PhaseOneMakernoteDescriptor(this));
        }

        public override string Name => "Phase One Makernote";

        protected override bool TryGetTagName(int tagType, out string tagName)
        {
            return _tagNameMap.TryGetValue(tagType, out tagName);
        }
    }
}