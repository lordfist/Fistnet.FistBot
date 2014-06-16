using System;

namespace Fistnet.FistBot.BL
{
    /// <summary>Permission table constants.</summary>
    /// <remarks>
    /// select 'public const int ' + naziv + ' = ' + convert(varchar(50), Id) + ';' from Permissions order by naziv
    /// </remarks>
    public static class Permissions
    {
        /// <summary>Permission for read access of Generation objektu.</summary>
        public const int Generation_Read = 0;

        /// <summary>Permission for edit of Generation objekata.</summary>
        public const int Generation_Update = 0;

        /// <summary>Permission for create of Generation objekata.</summary>
        public const int Generation_Insert = 0;

        /// <summary>Permission for delete of Generation objekata.</summary>
        public const int Generation_Delete = 0;

        /// <summary>Permission for read access of Strategy objektu.</summary>
        public const int Strategy_Read = 0;

        /// <summary>Permission for edit of Strategy objekata.</summary>
        public const int Strategy_Update = 0;

        /// <summary>Permission for create of Strategy objekata.</summary>
        public const int Strategy_Insert = 0;

        /// <summary>Permission for delete of Strategy objekata.</summary>
        public const int Strategy_Delete = 0;
    }
}