
namespace _6502asm_interpreter.System_Functions {
	class NOP {
		public static void execute(CPU cpu, MEM memory) {
			cpu.PC++;
		}
	}
}
