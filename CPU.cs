using System;


namespace _6502asm_interpreter {
	class CPU {
		public ushort PC = 0x0000;
		public byte SP, A, X, Y;
		public bool C, Z, I, D, B, O, N;
		private MEM memory;

		public CPU(MEM memory) {
			this.memory = memory;
			this.reset();
		}

		public void reset() {
			SP = A = X = Y = 0x00;
			C = Z = I = D = B = O = N = false;
			byte data1 = this.memory.getMem(0xFFFC);
			byte data2 = this.memory.getMem(0xFFFD);
			this.PC = (ushort)(data1 << 8);
			this.PC += data2;
		}

		public void tick() {
			CU.execute(this, this.memory);
		}

	}
}
