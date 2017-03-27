//
//  BleWapper.h
//  BleWapper
//
//  Created by etek on 16/6/14.
//  Copyright (c) 2016年 ETEK. All rights reserved.
//

#import <Foundation/Foundation.h>

// Version : 1.7
// Dtae    : 2017/3/17

// Version : 1.6
// Dtae    : 2017/3/10

// Version : 1.5
// Dtae    : 2017/2/13


NSString *MSG_BLEStateChangeNotification = @"BLEStateChangeNotification_etek_216920";
NSString *MSG_BLEGSensorInfoNotification = @"BLEGSensorInfoNotification_etek_216920";
NSString *MSG_BLEGSensorScanDeviceNotification = @"BLEGSensorScanDeviceNotification_etek_216920";
NSString *MSG_BLEGSensorScanTimerNotification = @"BLEGSensorScanTimerNotification_etek_216920";

#define STATE_DISCONNECTED    -2
#define STATE_CONNECTED_FAIL  -1
#define STATE_START_CONNECTED  0
#define STATE_CONNECTING       1
#define STATE_CONNECTED        2

#define KEY_VALUE  @"value_gsensor"

struct GSensor_info {
    int _axis_x; // 8bitGSensor数据
    int _axis_y; // 8bitGSensor数据
    int _axis_z; // 8bitGSensor数据
    int _axis_x1; // 12bitGSensor数据（bit15~bit4为有效GSensor数据，bit0~bit3为无效数据）
    int _axis_y1; // 12bitGSensor数据（bit15~bit4为有效GSensor数据，bit0~bit3为无效数据）
    int _axis_z1; // 12bitGSensor数据（bit15~bit4为有效GSensor数据，bit0~bit3为无效数据）
    int _temperature; // 目前没有用到 
    int _key_speed;
    int _key_back;
    int _key_mode1;
    int _key_mode2;
    int _key_extent5; // 目前没有用到
};

@interface BleWapper : NSObject

-(id)init:(Boolean)gSensor;
-(void)freeBleWapper;

-(void)StartScan:(int)times;
-(void)StopScan;
-(Boolean)ConnectDevice:(int)index;
-(void)DisconnectCurDevice;

-(bool)setVibrates:(bool)vibrates;
-(bool)setVibratesEx:(Byte)vibrates;

@end
