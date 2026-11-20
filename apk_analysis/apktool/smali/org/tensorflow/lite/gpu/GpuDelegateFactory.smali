.class public Lorg/tensorflow/lite/gpu/GpuDelegateFactory;
.super Ljava/lang/Object;
.source "GpuDelegateFactory.java"

# interfaces
.implements Lorg/tensorflow/lite/DelegateFactory;


# annotations
.annotation system Ldalvik/annotation/MemberClasses;
    value = {
        Lorg/tensorflow/lite/gpu/GpuDelegateFactory$Options;
    }
.end annotation


# static fields
.field private static final GPU_DELEGATE_CLASS_NAME:Ljava/lang/String; = "GpuDelegate"


# instance fields
.field private final options:Lorg/tensorflow/lite/gpu/GpuDelegateFactory$Options;


# direct methods
.method public constructor <init>()V
    .locals 1

    .line 160
    new-instance v0, Lorg/tensorflow/lite/gpu/GpuDelegateFactory$Options;

    invoke-direct {v0}, Lorg/tensorflow/lite/gpu/GpuDelegateFactory$Options;-><init>()V

    invoke-direct {p0, v0}, Lorg/tensorflow/lite/gpu/GpuDelegateFactory;-><init>(Lorg/tensorflow/lite/gpu/GpuDelegateFactory$Options;)V

    return-void
.end method

.method public constructor <init>(Lorg/tensorflow/lite/gpu/GpuDelegateFactory$Options;)V
    .locals 0

    .line 163
    invoke-direct {p0}, Ljava/lang/Object;-><init>()V

    .line 164
    iput-object p1, p0, Lorg/tensorflow/lite/gpu/GpuDelegateFactory;->options:Lorg/tensorflow/lite/gpu/GpuDelegateFactory$Options;

    return-void
.end method


# virtual methods
.method public create(Lorg/tensorflow/lite/RuntimeFlavor;)Lorg/tensorflow/lite/Delegate;
    .locals 3

    .line 170
    sget-object v0, Lorg/tensorflow/lite/gpu/GpuDelegateFactory$1;->$SwitchMap$org$tensorflow$lite$RuntimeFlavor:[I

    invoke-virtual {p1}, Ljava/lang/Enum;->ordinal()I

    move-result v1

    aget v0, v0, v1

    const/4 v1, 0x1

    if-eq v0, v1, :cond_1

    const/4 v1, 0x2

    if-ne v0, v1, :cond_0

    .line 176
    const-string p1, "com.google.android.gms.tflite.gpu"

    goto :goto_0

    .line 178
    :cond_0
    new-instance v0, Ljava/lang/IllegalArgumentException;

    new-instance v1, Ljava/lang/StringBuilder;

    invoke-direct {v1}, Ljava/lang/StringBuilder;-><init>()V

    const-string v2, "Unsupported runtime flavor "

    invoke-virtual {v1, v2}, Ljava/lang/StringBuilder;->append(Ljava/lang/String;)Ljava/lang/StringBuilder;

    invoke-virtual {v1, p1}, Ljava/lang/StringBuilder;->append(Ljava/lang/Object;)Ljava/lang/StringBuilder;

    invoke-virtual {v1}, Ljava/lang/StringBuilder;->toString()Ljava/lang/String;

    move-result-object p1

    invoke-direct {v0, p1}, Ljava/lang/IllegalArgumentException;-><init>(Ljava/lang/String;)V

    throw v0

    .line 173
    :cond_1
    const-string p1, "org.tensorflow.lite.gpu"

    .line 181
    :goto_0
    :try_start_0
    new-instance v0, Ljava/lang/StringBuilder;

    invoke-direct {v0}, Ljava/lang/StringBuilder;-><init>()V

    invoke-virtual {v0, p1}, Ljava/lang/StringBuilder;->append(Ljava/lang/String;)Ljava/lang/StringBuilder;

    const-string p1, "."

    invoke-virtual {v0, p1}, Ljava/lang/StringBuilder;->append(Ljava/lang/String;)Ljava/lang/StringBuilder;

    const-string p1, "GpuDelegate"

    invoke-virtual {v0, p1}, Ljava/lang/StringBuilder;->append(Ljava/lang/String;)Ljava/lang/StringBuilder;

    invoke-virtual {v0}, Ljava/lang/StringBuilder;->toString()Ljava/lang/String;

    move-result-object p1

    invoke-static {p1}, Ljava/lang/Class;->forName(Ljava/lang/String;)Ljava/lang/Class;

    move-result-object p1

    .line 182
    const-class v0, Lorg/tensorflow/lite/gpu/GpuDelegateFactory$Options;

    filled-new-array {v0}, [Ljava/lang/Class;

    move-result-object v0

    invoke-virtual {p1, v0}, Ljava/lang/Class;->getDeclaredConstructor([Ljava/lang/Class;)Ljava/lang/reflect/Constructor;

    move-result-object p1

    .line 183
    iget-object v0, p0, Lorg/tensorflow/lite/gpu/GpuDelegateFactory;->options:Lorg/tensorflow/lite/gpu/GpuDelegateFactory$Options;

    filled-new-array {v0}, [Ljava/lang/Object;

    move-result-object v0

    invoke-virtual {p1, v0}, Ljava/lang/reflect/Constructor;->newInstance([Ljava/lang/Object;)Ljava/lang/Object;

    move-result-object p1

    check-cast p1, Lorg/tensorflow/lite/Delegate;
    :try_end_0
    .catch Ljava/lang/ClassNotFoundException; {:try_start_0 .. :try_end_0} :catch_4
    .catch Ljava/lang/IllegalAccessException; {:try_start_0 .. :try_end_0} :catch_3
    .catch Ljava/lang/InstantiationException; {:try_start_0 .. :try_end_0} :catch_2
    .catch Ljava/lang/NoSuchMethodException; {:try_start_0 .. :try_end_0} :catch_1
    .catch Ljava/lang/reflect/InvocationTargetException; {:try_start_0 .. :try_end_0} :catch_0

    return-object p1

    :catch_0
    move-exception p1

    goto :goto_1

    :catch_1
    move-exception p1

    goto :goto_1

    :catch_2
    move-exception p1

    goto :goto_1

    :catch_3
    move-exception p1

    goto :goto_1

    :catch_4
    move-exception p1

    .line 189
    :goto_1
    new-instance v0, Ljava/lang/IllegalStateException;

    const-string v1, "Error creating GPU delegate"

    invoke-direct {v0, v1, p1}, Ljava/lang/IllegalStateException;-><init>(Ljava/lang/String;Ljava/lang/Throwable;)V

    throw v0
.end method
