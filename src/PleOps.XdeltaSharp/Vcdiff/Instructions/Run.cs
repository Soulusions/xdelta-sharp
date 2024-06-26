﻿// Copyright (c) 2019 Benito Palacios Sánchez

// Permission is hereby granted, free of charge, to any person obtaining a copy
// of this software and associated documentation files (the "Software"), to deal
// in the Software without restriction, including without limitation the rights
// to use, copy, modify, merge, publish, distribute, sublicense, and/or sell
// copies of the Software, and to permit persons to whom the Software is
// furnished to do so, subject to the following conditions:

// The above copyright notice and this permission notice shall be included in all
// copies or substantial portions of the Software.

// THE SOFTWARE IS PROVIDED "AS IS", WITHOUT WARRANTY OF ANY KIND, EXPRESS OR
// IMPLIED, INCLUDING BUT NOT LIMITED TO THE WARRANTIES OF MERCHANTABILITY,
// FITNESS FOR A PARTICULAR PURPOSE AND NONINFRINGEMENT. IN NO EVENT SHALL THE
// AUTHORS OR COPYRIGHT HOLDERS BE LIABLE FOR ANY CLAIM, DAMAGES OR OTHER
// LIABILITY, WHETHER IN AN ACTION OF CONTRACT, TORT OR OTHERWISE, ARISING FROM,
// OUT OF OR IN CONNECTION WITH THE SOFTWARE OR THE USE OR OTHER DEALINGS IN THE
// SOFTWARE.
namespace PleOps.XdeltaSharp.Vcdiff.Instructions
{
    using System.IO;

    public class Run : Instruction
    {
        public Run(byte sizeInTable)
            : base(sizeInTable, InstructionType.Run)
        {
        }

        public byte Data {
            get;
            private set;
        }

        public override void DecodeInstruction(Window window, Stream input, Stream output)
        {
            Data = window.Data.ReadByte();

            byte[] dataArray = new byte[Size];
            for (long i = 0; i < Size; i++)
                dataArray[i] = Data;

            output.Write(dataArray, 0, dataArray.Length);
        }

        public override string ToString()
        {
            return string.Format("RUN {0:X8}, 0x{1:X2}", Size, Data);
        }
    }
}
