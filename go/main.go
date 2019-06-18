package main

// #include <stdint.h>
// typedef void (*nativeCallback)(int32_t value);
// static void bridge_nativeCallback(nativeCallback callback, int32_t value){
// 	callback(value);
// }
//
import "C"

//export CallMeBack
func CallMeBack(callback C.nativeCallback, value int32) {
	C.bridge_nativeCallback(callback, C.int32_t(value))
}

func main() {}
