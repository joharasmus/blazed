# blazed
[![GitHub builds](https://github.com/joharasmus/blazed/workflows/GitHub%20CI/badge.svg)](https://github.com/joharasmus/blazed/actions) 
[![codecov](https://codecov.io/gh/joharasmus/blazed/branch/master/graph/badge.svg)](https://codecov.io/gh/joharasmus/blazed)

blazed is a freestanding fork of the "iced" project. It is very much WIP.

iced is a blazing fast and correct x86 (16/32/64-bit) instruction decoder, disassembler and assembler.

- 👍 Supports all Intel and AMD instructions
- 👍 Correct: All instructions are tested and iced has been tested against other disassemblers/assemblers (xed, gas, objdump, masm, dumpbin, nasm, ndisasm) and fuzzed
- 👍 100% C# code
- 👍 The formatter supports masm, nasm, gas (AT&T), Intel (XED) and there are many options to customize the output
- 👍 Blazing fast: Decodes >250 MB/s and decode+format >130 MB/s
- 👍 Small decoded instructions, only 40 bytes and the decoder doesn't allocate any memory
- 👍 Create instructions with code assembler, eg. `asm.mov(eax, edx)`
- 👍 The encoder can be used to re-encode decoded instructions at any address
- 👍 API to get instruction info, eg. read/written registers, memory and rflags bits; CPUID feature flag, control flow info, etc

[README](https://github.com/joharasmus/blazed/blob/master/src/Blazed/README.md)

# License

MIT
