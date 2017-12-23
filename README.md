# Reference Tutorial
- https://www.youtube.com/watch?v=Urh97eeG53g

# Solution

## รายละเอียด
ต้องการทำระบบที่ไป call web service ตัวอื่น เพื่อไป get ค่าเวลาพระอาทิตย์ขึ้น(Sunrise) และเวลาที่พระอาทิตย์ตก(Sunset) ของแต่ละวัน แล้วนำมาแปลงจาก string ให้กลายเป็น DateTime

## ทดสอบอะไรบ้าง
1. ServiceSunsetCalculator_ImplementISunsetCalculator ทดสอบว่า class ServiceSunsetCalculator ได้ implement interface ที่ชื่อว่า ISunsetCalculator หรือไม่

2. ParseJsonSunsetValue_OnGoodData_ReturnExpectedString ทดสอบว่า method ParseSunset ทำงานถูกต้อง ถ้าหากได้รับ json ถูก format 

3. ParseJsonSunsetValue_OnBadData_ThrowArgumentxception ทดสอบว่า method ParseSunset ต้อง throw ArgumentException ออกมา ถ้าได้รับ error json

4. ToLocalTime_OnValidValue_ReturnsExpectedDateTime ทดสอบว่า ส่งเวลาแบบ string กับ วันที่เข้าไป method ToLocalTime จะแปลงเวลาได้ถูกต้อง

5. GetSunset_OnValidDate_ReturnsExpectedDateTime ทดสอบว่า เมื่อเรียก method GetSunset โดยส่งแต่วันที่เข้าไป จะได้ วันที่และเวลาที่พระอาทิตย์ขึ้นกลับมา

## dependency
ใน class SolarService.GetServiceData เป็นการจำลอง response ที่มาจาก web service อีกตัวนึง 

เพื่อให้การทำ unit test สามารถควบคุมค่าตัวแปรได้ และไม่อยากเรียก web service จริงๆทีุกครั้งที่รัน test เลยต้องตัด(isolate) dependecy โดยการสร้าง ISolarService ขึ้นมา และใช้ moq เป็นตัวสร้าง web service ตัวปลอมขึ้นมาใน test ที่ชื่อ GetSunset_OnValidDate_ReturnsExpectedDateTime 

ก่อนจะใช้ moq ก็มีการสร้าง stub ขึ้นมาใช้งานเองไป ลองดูในประวัติการ commit
