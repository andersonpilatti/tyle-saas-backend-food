# Tyle Food Backend

Leia `../../AGENTS.md` e `../../.docs/index.md` antes de analisar ou alterar este repositório. Use a skill pertinente em `../../.agents/skills/` e trate o código desta solução como fonte de verdade operacional.

Esta API expõe o domínio de alimentação e PDV em `api/v1/...`; o frontend deve consumi-la somente através do BFF. Novas entidades devem herdar `BaseEntity<long>` e avaliar explicitamente `ISoftDeletableEntity<long>`.
