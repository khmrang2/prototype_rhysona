# RhySona

> Unity 기반 2D 모바일 액션 RPG 게임

---

## 프로젝트 개요

RhySona는 스테이지 기반의 2D 모바일 액션 RPG 게임입니다. 플레이어는 다양한 스테이지를 진행하며 적을 처치하고, 아이템과 버프를 수집·강화하여 캐릭터를 성장시킵니다. 가챠 시스템과 상점을 통한 아이템 획득, 인벤토리 관리, Google Play Games 연동 등 상용 수준의 모바일 게임 기능을 구현하였습니다.

## 기술 스택

| 분류 | 기술 |
|------|------|
| 엔진 | Unity (URP) |
| 언어 | C# |
| 플랫폼 | Android |
| 광고 | Google Mobile Ads |
| 로그인 | Google Play Games Services (GPGS) |
| 데이터 | JSON (아이템/버프 데이터), PlayerPrefs (세이브) |
| UI | TextMesh Pro, Violet Theme UI |
| 이펙트 | Particle System, Shader (HLSL/ShaderLab) |

## 프로젝트 구조

```
Assets/
├── Resources/
│   ├── Script/           # 게임 로직
│   │   ├── Player/       # 플레이어 관련 스크립트
│   │   ├── Enemy/        # 적 AI 및 행동
│   │   ├── BuffState/    # 버프 시스템
│   │   ├── Item/         # 아이템 시스템
│   │   ├── Stage/        # 스테이지 관리
│   │   ├── UI/           # UI 매니저 및 패널
│   │   ├── GameManger/   # 게임 매니저
│   │   ├── DataScript/   # 데이터 로딩/파싱
│   │   ├── Ads/          # 광고 연동
│   │   ├── GPGS/         # Google Play Games 연동
│   │   └── Upgrade/      # 강화 시스템
│   ├── Data/             # JSON 데이터 (아이템, 버프)
│   ├── Prefabs/          # 프리팹
│   ├── Anim/             # 애니메이션 클립
│   ├── Sound/            # 사운드 리소스
│   ├── Image/            # 이미지 리소스
│   └── Particle/         # 파티클 이펙트
├── Scenes/               # 게임 씬 (11개 스테이지 + 메인/로딩/상점)
└── Plugins/              # 외부 플러그인
```

## 주요 기능

- **스테이지 시스템** — 11개 스테이지 (Stage0~Stage10) 순차 진행, 스크롤 스냅 기반 스테이지 선택
- **전투 시스템** — 플레이어/적 공격·피격·사망 애니메이션, 투사체, 데미지 텍스트
- **아이템 & 버프** — JSON 기반 아이템/버프 데이터, 등급(Rarity) 시스템, 강화 시스템
- **가챠 시스템** — 아이템 랜덤 획득
- **상점 & 인벤토리** — 아이템 구매·장착·관리 UI
- **세이브/로드** — PlayerPrefs 기반 게임 진행도 저장
- **광고** — Google Mobile Ads 연동 (보상형 광고)
- **소셜** — Google Play Games 로그인 연동

## 팀 구성 및 나의 역할

5인 팀 프로젝트 (2024.08 ~ 2025.05)

| 이름 | 커밋 수 | 주요 역할 |
|------|---------|----------|
| **khmrang2 (본인)** | **156** | 프로젝트 리드, UI/UX, 애니메이션, 스테이지 시스템 |
| KJHan1256 | 77 | - |
| ryusiwoo0112 | 46 | - |
| 20yeon | 39 | - |
| kirnrang | 27 | - |

### 나의 기여 내역 (커밋 로그 기반)

**UI/UX 시스템 설계 및 구현**
- 상점(Store) 팝업 UI 및 인벤토리 시스템 전체 설계·구현
- UIPanel, Manager 구조 설계 및 정리
- 아이템 등급(Rarity), 슬롯 시스템 구현
- 강화석 시스템 설계 및 PlayerPrefs 연동
- 폰트 적용 및 UI 비율 정상화 작업

**애니메이션 시스템**
- 플레이어 공격 애니메이션 연동
- 적(Enemy) 공격/피격/사망/이동 애니메이션 전체 구현
- 파티클 수치 조정 및 프리팹 Sorting Layer 설정

**스테이지 시스템**
- 스테이지 선택 스크롤 스냅 최적화
- 스테이지 데이터 관리 및 로딩 시스템 구현
- 11개 스테이지 씬 구성

**데이터 시스템**
- JSON 기반 아이템/버프 데이터 구조 설계
- 아이템 효과 적용 로직 구현
- 버프 테이블 설계 및 수정

**기타**
- 가챠 시스템 버그 수정
- Google Ads 슬롯 오류 수정
- 코드 리팩토링 및 전반적인 버그 픽스
- PR 관리 (70+ Pull Requests 머지 관리)

## 빌드 방법

1. **Unity Hub**에서 프로젝트 열기 (URP 호환 Unity 버전 필요)
2. `File > Build Settings > Android` 선택
3. Player Settings에서 Keystore 설정 (user.keystore 파일 사용)
4. Build and Run
