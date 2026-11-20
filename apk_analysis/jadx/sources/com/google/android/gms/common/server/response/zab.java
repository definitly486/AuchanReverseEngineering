package com.google.android.gms.common.server.response;

import java.io.BufferedReader;

/* JADX INFO: compiled from: com.google.android.gms:play-services-base@@18.7.2 */
/* JADX INFO: loaded from: classes.dex */
final class zab implements zai {
    zab() {
    }

    @Override // com.google.android.gms.common.server.response.zai
    public final /* synthetic */ Object zaa(FastParser fastParser, BufferedReader bufferedReader) {
        return Long.valueOf(fastParser.zac(bufferedReader));
    }
}
