# 테라포밍

이 프로젝트는 3D 행성 서바이벌 게임 개발을(를) 위한 Unity를 사용하여 개발되었습니다. 아래는 프로젝트의 브랜치 규칙, 풀 규칙, 커밋 규칙 등에 대한 세부 사항입니다.

## 목차

- [브랜치 규칙](#브랜치-규칙)
- [풀 요청 규칙](#풀-요청-규칙)
- [커밋 메시지 규칙](#커밋-메시지-규칙)
- [기타 규칙](#기타-규칙)

## 브랜치 규칙

1. **메인 브랜치 (`master`)**
   - 항상 배포 가능한 상태를 유지합니다.
   - 모든 기능은 이 브랜치에 병합되기 전에 충분한 검토와 테스트가 필요합니다.

2. **개발 브랜치 (`develop`)**
   - 모든 기능 개발과 버그 수정을 위한 브랜치입니다.
   - `master` 브랜치에 병합하기 전에 이 브랜치에서 최종 테스트를 진행합니다.

3. **기능 브랜치 (`feature/브랜치명`)**
   - 새로운 기능을 개발할 때 사용합니다.
   - `develop` 브랜치에서 분기하여 작업하며, 완료 후 `develop` 브랜치에 병합합니다.
   - 예: `feature/add-login-form`

4. **버그 수정 브랜치 (`bugfix/브랜치명`)**
   - 버그 수정을 위해 사용합니다.
   - `develop` 브랜치에서 분기하여 작업하며, 완료 후 `develop` 브랜치에 병합합니다.
   - 예: `bugfix/fix-login-error`

5. **핫픽스 브랜치 (`hotfix/브랜치명`)**
   - 프로덕션 환경에서 발생한 심각한 문제를 신속하게 해결하기 위해 사용합니다.
   - `master` 브랜치에서 분기하여 작업하며, 완료 후 `main` 브랜치와 `develop` 브랜치에 병합합니다.
   - 예: `hotfix/critical-bug`

## 풀 요청 규칙

1. **풀 요청 제출**
   - 모든 풀 요청은 코드 리뷰를 거쳐야 합니다.
   - 각 풀 요청은 관련 이슈를 명시해야 합니다.
   - 테스트가 완료된 상태에서 제출해야 합니다.

2. **검토 및 승인**
   - 최소 1명의 팀원이 코드 리뷰를 수행해야 합니다.
   - 리뷰어는 코드의 품질과 기능적 요구 사항을 검토합니다.

3. **병합**
   - 풀 요청이 승인되면 `develop` 또는 `master` 브랜치에 병합됩니다.
   - 병합 전에 모든 충돌을 해결해야 합니다.

## 커밋 메시지 규칙

1. **형식**
   - 커밋 메시지는 다음과 같은 형식을 따릅니다:
     ```
     [타입]: [설명]

     [선택적 본문]
     ```
   - 예: `feat: add user login feature`

2. **타입**
   - `feat`: 새로운 기능 추가
   - `fix`: 버그 수정
   - `docs`: 문서 수정
   - `style`: 코드 스타일 수정 (포맷팅 등)
   - `refactor`: 코드 리팩토링
   - `test`: 테스트 코드 추가 또는 수정
   - `chore`: 빌드 프로세스 또는 보조 도구 변경

3. **설명**
   - 커밋 메시지의 설명은 간결하고 명확해야 합니다.
   - 커밋의 목적과 변경 내용을 이해할 수 있도록 작성합니다.

## 기타 규칙

- **코드 스타일**
  - [코딩 표준 또는 스타일 가이드]에 따라 코드를 작성합니다.
  
- **테스트**
  - 모든 새로운 기능과 수정 사항에 대해 적절한 테스트를 작성합니다.
  
- **문서화**
  - 코드 변경에 따라 관련 문서를 업데이트합니다.

## 기여하기

기여를 원하시면 [기여 가이드라인]을 참고해 주세요.

## 라이선스

이 프로젝트는 [라이선스 이름] 라이선스 하에 배포됩니다. 자세한 내용은 [LICENSE] 파일을 확인해 주세요.

