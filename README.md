# [C#]Winform을 사용한 DataPush Tool

1. 기본동작 메커니즘 : PC상의 파일을 Uart 송신하여 모듈에 전송한다.
       -> 모듈이 Uart통신을 수신하게 되면 데이터 처리 이후 Echo 한다.
        -> Echo를 받은 Tool이 Msg_Box에 Data를 띄워준다.

2. Uart 송.수신을 이용한 데이터 / 인증서 push / size (512KByte : 1packet) tool.

3. 데이터 파일은 모든 파일(`*.*`) 가져오기 이후 내보내기 가능.

4. 인증서 파일은 X509Certificate으로 디코딩 가능한 모든 파일 가능.

5. cmd로 원하는 data를 uart송신 가능.

   5-1. 최근에 보낸 cmd(명령어) 키보드 ↑및 ↓으로 선택가능

   

