package com.google.android.gms.common.server.response;

import java.io.BufferedReader;

/* JADX INFO: compiled from: com.google.android.gms:play-services-base@@18.7.2 */
/* JADX INFO: loaded from: classes.dex */
final class zae implements zai {
    zae() {
    }

    @Override // com.google.android.gms.common.server.response.zai
    public final /* bridge */ /* synthetic */ Object zaa(FastParser fastParser, BufferedReader bufferedReader) {
        return Boolean.valueOf(fastParser.zae(bufferedReader, false));
    }
}
