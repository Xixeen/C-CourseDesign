#include <stdio.h>
#include <stdlib.h>
#include <time.h>

#define WINDOW_SIZE 5
#define TIMEOUT 3 // 超时时间设置为3秒

typedef struct {
    int seqNum;    // 数据包序号
    time_t sendTime; // 发送时间
    int acked;     // 是否已确认
} Packet;

typedef struct {
    Packet packets[WINDOW_SIZE];
    int start; // 窗口开始序号
    int end;   // 窗口结束序号
} SlidingWindow;

// 初始化窗口和数据包
void initializeWindow(SlidingWindow* window) {
    window->start = 0;
    window->end = WINDOW_SIZE - 1;
    for (int i = 0; i < WINDOW_SIZE; ++i) {
        window->packets[i].seqNum = i;
        window->packets[i].sendTime = 0; // 未发送
        window->packets[i].acked = 0;    // 未确认
    }
}

// 模拟发送数据包
void sendPacket(SlidingWindow* window, int packetIndex) {
    if (packetIndex < WINDOW_SIZE) {
        window->packets[packetIndex].sendTime = time(NULL); // 记录发送时间
        window->packets[packetIndex].acked = 0; // 设置为未确认
        printf("Packet %d sent at time %ld\n", window->packets[packetIndex].seqNum, window->packets[packetIndex].sendTime);
    }
}
// 检查并处理超时的数据包
void checkTimeouts(SlidingWindow* window) {
    time_t currentTime = time(NULL);
    for (int i = 0; i < WINDOW_SIZE; ++i) {
        if (!window->packets[i].acked && window->packets[i].sendTime > 0) { // 如果数据包已发送但未确认
            if (currentTime - window->packets[i].sendTime > TIMEOUT) { // 检查是否超时
                printf("Packet %d timed out, resending...\n", window->packets[i].seqNum);
                sendPacket(window, i); // 重新发送数据包
            }
        }
    }
}
// 模拟接收到确认
void acknowledgePacket(SlidingWindow* window, int packetIndex) {
    if (packetIndex < WINDOW_SIZE) {
        window->packets[packetIndex].acked = 1; // 标记为已确认
        printf("Packet %d acknowledged.\n", window->packets[packetIndex].seqNum);
    }
}

int main() {
    SlidingWindow window;
    initializeWindow(&window);

    // 模拟发送所有数据包
    for (int i = 0; i < WINDOW_SIZE; ++i) {
        sendPacket(&window, i);
    }

    // 模拟部分确认和超时重传
    acknowledgePacket(&window, 1); // 确认第2个数据包
    acknowledgePacket(&window, 3); // 确认第4个数据包

    Sleep(5000); // 等待一段时间，使得一些数据包超时

    // 检查并处理超时的数据包
    checkTimeouts(&window);

    return 0;
}
