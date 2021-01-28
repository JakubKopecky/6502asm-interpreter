
namespace _6502asm_interpreter.Jmp_Calls {
    class JMP {
		public static void execute(CPU cpu, MEM memory) {
			switch (memory.getMem(cpu.PC)) {
				case 0x4C:
					JMP.JMP_ABS(cpu, memory);
					return;
				case 0x6C:
					JMP.JMP_INDIRECT(cpu, memory);
					return;
			}
		}

		private static void JMP_ABS(CPU cpu, MEM memory) {
			byte data1 = memory.getMem((ushort)(cpu.PC + 0x0001));
			byte data2 = memory.getMem((ushort)(cpu.PC + 0x0002));
			cpu.PC = (ushort)(data1 << 8);
			cpu.PC += data2;
		}

		private static void JMP_INDIRECT(CPU cpu, MEM memory) {
			byte data1 = memory.getMem((ushort)(cpu.PC + 0x0001));
			byte data2 = memory.getMem((ushort)(cpu.PC + 0x0002));
			ushort address = (ushort)(data1 << 8);
			address += data2;
			byte jumpToH = memory.getMem(address);
			byte jumpToL = memory.getMem((ushort)(address + 0x0001));
			cpu.PC = (ushort)(jumpToH << 8);
			cpu.PC += jumpToL;
		}
	}
}