
namespace _6502asm_interpreter {
	class MEM {
		private const uint MAX_MEM = 65536;
		private byte[] memory = new byte[MAX_MEM];

		public MEM() {
			this.reset();
		}

		public void setMem(ushort address, byte value) {
			this.memory[address] = value;
		}

		public void setMem(byte addH, byte addL, byte value) {
			ushort address = (ushort)(addH << 8);
			address += addL;
			this.memory[address] = value;
		}

		public byte getMem(ushort address) {
			return this.memory[address];
		}

		public byte getMem(byte addH, byte addL) {
			ushort address = (ushort)(addH << 8);
			address += addL;
			return this.memory[address];
		}

		public void reset() {
			for(int i = 0; i < MAX_MEM; i++) {
				this.memory[i] = 0xEA;
			}
		}
	}
}
