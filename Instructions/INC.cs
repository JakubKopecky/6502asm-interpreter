
namespace _6502asm_interpreter.Inc_Dec {
	class INC {
		public static void execute(CPU cpu, MEM memory) {
			switch (memory.getMem(cpu.PC)) {
				case 0xE6: case 0xEE:
					INC.INC_ZP(cpu, memory);
					return;
				case 0xF6: case 0xFE:
					return;
			}
		}

		private static void INC_ZP(CPU cpu, MEM memory) {
			byte data1 = memory.getMem((ushort)(cpu.PC + 0x0001));
			byte data2 = memory.getMem((ushort)(cpu.PC + 0x0002));
			byte x = memory.getMem(data1, data2);
			x++;
			memory.setMem(data1, data2, x);
			cpu.Z = (x == 0x00);
			cpu.N = (x & 0x80) == 0x80;
			cpu.PC += 3;
		}
	}
}
