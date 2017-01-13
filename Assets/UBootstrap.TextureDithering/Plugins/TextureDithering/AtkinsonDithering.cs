﻿/*
   This file implements error pushing of dithering via Atkinson kernel.
   This is free and unencumbered software released into the public domain.
*/

namespace UBootstrap.TextureDithering
{
    class AtkinsonDithering : DitheringBase
    {
        public AtkinsonDithering (FindColor colorfunc) : base (colorfunc)
        {
        }

        override protected void PushError (int x, int y, float[] quantError)
        {
            // Push error
            //        X    1/8   1/8 
            // 1/8   1/8   1/8
            //       1/8

            int xMinusOne = x - 1;
            int xPlusOne = x + 1;
            int xPlusTwo = x + 2;
            int yPlusOne = y + 1;
            int yPlusTwo = y + 2;

            float multiplier = 1.0f / 8.0f; // Atkinson Dithering has same multiplier for every item

            // Current row
            int currentRow = y;
            if (this.IsValidCoordinate (xPlusOne, currentRow)) {
                this.ModifyImageWithErrorAndMultiplier (xPlusOne, currentRow, quantError, multiplier);
            }

            if (this.IsValidCoordinate (xPlusTwo, currentRow)) {
                this.ModifyImageWithErrorAndMultiplier (xPlusTwo, currentRow, quantError, multiplier);
            }

            // Next row
            currentRow = yPlusOne;
            if (this.IsValidCoordinate (xMinusOne, currentRow)) {
                this.ModifyImageWithErrorAndMultiplier (xMinusOne, currentRow, quantError, multiplier);
            }

            if (this.IsValidCoordinate (x, currentRow)) {
                this.ModifyImageWithErrorAndMultiplier (x, currentRow, quantError, multiplier);
            }

            if (this.IsValidCoordinate (xPlusOne, currentRow)) {
                this.ModifyImageWithErrorAndMultiplier (xPlusOne, currentRow, quantError, multiplier);
            }

            // Next row
            currentRow = yPlusTwo;
            if (this.IsValidCoordinate (x, currentRow)) {
                this.ModifyImageWithErrorAndMultiplier (x, currentRow, quantError, multiplier);
            }
        }
    }
}