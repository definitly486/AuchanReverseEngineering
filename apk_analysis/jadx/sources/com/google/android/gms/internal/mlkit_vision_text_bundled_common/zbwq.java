package com.google.android.gms.internal.mlkit_vision_text_bundled_common;

import sun.misc.Unsafe;

/* JADX INFO: compiled from: com.google.mlkit:text-recognition-bundled-common@@17.0.0 */
/* JADX INFO: loaded from: classes2.dex */
final class zbwq extends zbwr {
    zbwq(Unsafe unsafe) {
        super(unsafe);
    }

    @Override // com.google.android.gms.internal.mlkit_vision_text_bundled_common.zbwr
    public final double zba(Object obj, long j) {
        return Double.longBitsToDouble(this.zba.getLong(obj, j));
    }

    @Override // com.google.android.gms.internal.mlkit_vision_text_bundled_common.zbwr
    public final float zbb(Object obj, long j) {
        return Float.intBitsToFloat(this.zba.getInt(obj, j));
    }

    /*  JADX ERROR: JadxRuntimeException in pass: InlineMethods
        jadx.core.utils.exceptions.JadxRuntimeException: Failed to process method for inline: com.google.android.gms.internal.mlkit_vision_text_bundled_common.zbws.zbi(java.lang.Object, long, boolean):void
        	at jadx.core.dex.visitors.InlineMethods.processInvokeInsn(InlineMethods.java:80)
        	at jadx.core.dex.visitors.InlineMethods.visit(InlineMethods.java:50)
        Caused by: java.util.ConcurrentModificationException
        	at java.base/java.util.ArrayList.removeIf(ArrayList.java:1695)
        	at java.base/java.util.ArrayList.removeIf(ArrayList.java:1660)
        	at jadx.core.dex.instructions.args.SSAVar.removeUse(SSAVar.java:139)
        	at jadx.core.dex.instructions.args.SSAVar.use(SSAVar.java:132)
        	at jadx.core.dex.nodes.InsnNode.rebindArgs(InsnNode.java:514)
        	at jadx.core.dex.instructions.mods.TernaryInsn.rebindArgs(TernaryInsn.java:100)
        	at jadx.core.dex.nodes.InsnNode.rebindArgs(InsnNode.java:517)
        	at jadx.core.utils.BlockUtils.replaceInsn(BlockUtils.java:1415)
        	at jadx.core.utils.BlockUtils.replaceInsn(BlockUtils.java:1424)
        	at jadx.core.dex.visitors.InlineMethods.inlineMethod(InlineMethods.java:89)
        	at jadx.core.dex.visitors.InlineMethods.processInvokeInsn(InlineMethods.java:78)
        	... 1 more
        */
    @Override // com.google.android.gms.internal.mlkit_vision_text_bundled_common.zbwr
    public final void zbc(java.lang.Object r2, long r3, boolean r5) {
        /*
            r1 = this;
            boolean r0 = com.google.android.gms.internal.mlkit_vision_text_bundled_common.zbws.zbb
            if (r0 == 0) goto L8
            com.google.android.gms.internal.mlkit_vision_text_bundled_common.zbws.zbi(r2, r3, r5)
            return
        L8:
            com.google.android.gms.internal.mlkit_vision_text_bundled_common.zbws.zbj(r2, r3, r5)
            return
        */
        throw new UnsupportedOperationException("Method not decompiled: com.google.android.gms.internal.mlkit_vision_text_bundled_common.zbwq.zbc(java.lang.Object, long, boolean):void");
    }

    @Override // com.google.android.gms.internal.mlkit_vision_text_bundled_common.zbwr
    public final void zbd(Object obj, long j, byte b) {
        if (zbws.zbb) {
            zbws.zbD(obj, j, b);
        } else {
            zbws.zbE(obj, j, b);
        }
    }

    @Override // com.google.android.gms.internal.mlkit_vision_text_bundled_common.zbwr
    public final void zbe(Object obj, long j, double d) {
        this.zba.putLong(obj, j, Double.doubleToLongBits(d));
    }

    @Override // com.google.android.gms.internal.mlkit_vision_text_bundled_common.zbwr
    public final void zbf(Object obj, long j, float f) {
        this.zba.putInt(obj, j, Float.floatToIntBits(f));
    }

    @Override // com.google.android.gms.internal.mlkit_vision_text_bundled_common.zbwr
    public final boolean zbg(Object obj, long j) {
        return zbws.zbb ? zbws.zbt(obj, j) : zbws.zbu(obj, j);
    }
}
