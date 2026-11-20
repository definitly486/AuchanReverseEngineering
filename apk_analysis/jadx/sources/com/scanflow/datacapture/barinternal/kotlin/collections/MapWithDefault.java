package com.scanflow.datacapture.barinternal.kotlin.collections;

import java.util.Map;
import kotlin.jvm.internal.markers.KMappedMarker;

/* JADX INFO: compiled from: MapWithDefault.kt */
/* JADX INFO: loaded from: classes3.dex */
interface MapWithDefault extends Map, KMappedMarker {
    Object getOrImplicitDefault(Object obj);
}
