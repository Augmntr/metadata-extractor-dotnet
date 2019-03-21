using System.Diagnostics.CodeAnalysis;
using JetBrains.Annotations;

namespace MetadataExtractor.Formats.Exif.Makernotes
{
    /// <summary>
    /// Provides human-readable string representations of tag values stored in a <see cref="PhaseOneMakernoteDirectory"/>.
    /// </summary>
    /// <remarks>Using information from https://www.sno.phy.queensu.ca/~phil/exiftool/TagNames/PhaseOne.html</remarks>
    /// <author>Charlie Matherne, adapted from Drew Noakes https://drewnoakes.com</author>
    [SuppressMessage("ReSharper", "MemberCanBePrivate.Global")]
    public class PhaseOneMakernoteDescriptor : TagDescriptor<PhaseOneMakernoteDirectory>
    {
        public PhaseOneMakernoteDescriptor([NotNull] PhaseOneMakernoteDirectory directory)
            : base(directory)
        {
        }
    }
}