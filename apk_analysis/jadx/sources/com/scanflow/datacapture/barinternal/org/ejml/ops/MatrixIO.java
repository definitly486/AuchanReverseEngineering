package com.scanflow.datacapture.barinternal.org.ejml.ops;

import com.scanflow.datacapture.barinternal.a.a$$ExternalSyntheticThrowCCEIfNotNull0;
import com.scanflow.datacapture.barinternal.org.ejml.data.CMatrix;
import com.scanflow.datacapture.barinternal.org.ejml.data.Complex_F32;
import com.scanflow.datacapture.barinternal.org.ejml.data.Complex_F64;
import com.scanflow.datacapture.barinternal.org.ejml.data.DMatrix;
import com.scanflow.datacapture.barinternal.org.ejml.data.DMatrixSparseCSC;
import com.scanflow.datacapture.barinternal.org.ejml.data.DMatrixSparseTriplet;
import com.scanflow.datacapture.barinternal.org.ejml.data.FMatrix;
import com.scanflow.datacapture.barinternal.org.ejml.data.FMatrixSparseCSC;
import com.scanflow.datacapture.barinternal.org.ejml.data.FMatrixSparseTriplet;
import com.scanflow.datacapture.barinternal.org.ejml.data.Matrix;
import com.scanflow.datacapture.barinternal.org.ejml.data.MatrixSparse;
import com.scanflow.datacapture.barinternal.org.ejml.data.MatrixType;
import com.scanflow.datacapture.barinternal.org.ejml.data.ZMatrix;
import java.io.PrintStream;
import java.util.Arrays;
import java.util.Locale;

/* JADX INFO: loaded from: classes3.dex */
public abstract class MatrixIO {
    public static String MATLAB_FORMAT = "%.8E";
    public static Locale local = Locale.US;

    /* JADX INFO: renamed from: com.scanflow.datacapture.barinternal.org.ejml.ops.MatrixIO$1, reason: invalid class name */
    static /* synthetic */ class AnonymousClass1 {
        static final /* synthetic */ int[] $SwitchMap$org$ejml$data$MatrixType;

        static {
            int[] iArr = new int[MatrixType.values().length];
            $SwitchMap$org$ejml$data$MatrixType = iArr;
            try {
                iArr[MatrixType.DDRM.ordinal()] = 1;
            } catch (NoSuchFieldError unused) {
            }
            try {
                $SwitchMap$org$ejml$data$MatrixType[MatrixType.FDRM.ordinal()] = 2;
            } catch (NoSuchFieldError unused2) {
            }
            try {
                $SwitchMap$org$ejml$data$MatrixType[MatrixType.ZDRM.ordinal()] = 3;
            } catch (NoSuchFieldError unused3) {
            }
            try {
                $SwitchMap$org$ejml$data$MatrixType[MatrixType.CDRM.ordinal()] = 4;
            } catch (NoSuchFieldError unused4) {
            }
            try {
                $SwitchMap$org$ejml$data$MatrixType[MatrixType.DSCC.ordinal()] = 5;
            } catch (NoSuchFieldError unused5) {
            }
            try {
                $SwitchMap$org$ejml$data$MatrixType[MatrixType.DTRIPLET.ordinal()] = 6;
            } catch (NoSuchFieldError unused6) {
            }
            try {
                $SwitchMap$org$ejml$data$MatrixType[MatrixType.FSCC.ordinal()] = 7;
            } catch (NoSuchFieldError unused7) {
            }
            try {
                $SwitchMap$org$ejml$data$MatrixType[MatrixType.FTRIPLET.ordinal()] = 8;
            } catch (NoSuchFieldError unused8) {
            }
        }
    }

    public static void print(PrintStream printStream, Matrix matrix) {
        switch (AnonymousClass1.$SwitchMap$org$ejml$data$MatrixType[matrix.getType().ordinal()]) {
            case 1:
                print(printStream, (DMatrix) matrix, "%11.4E");
                return;
            case 2:
                print(printStream, (FMatrix) matrix, "%11.4E");
                return;
            case 3:
                print(printStream, (ZMatrix) matrix, "%11.4E");
                return;
            case 4:
                print(printStream, (CMatrix) matrix, "%11.4E");
                return;
            case 5:
                print(printStream, (DMatrixSparseCSC) matrix, "%11.4E");
                return;
            case 6:
                a$$ExternalSyntheticThrowCCEIfNotNull0.m(matrix);
                print(printStream, (DMatrixSparseTriplet) null, "%11.4E");
                return;
            case 7:
                print(printStream, (FMatrixSparseCSC) matrix, "%11.4E");
                return;
            case 8:
                a$$ExternalSyntheticThrowCCEIfNotNull0.m(matrix);
                print(printStream, (FMatrixSparseTriplet) null, "%11.4E");
                return;
            default:
                throw new RuntimeException("Unknown type " + matrix.getType());
        }
    }

    public static void print(PrintStream printStream, DMatrix dMatrix) {
        print(printStream, dMatrix, "%11.4E");
    }

    public static void print(PrintStream printStream, DMatrix dMatrix, String str) {
        if (str.equalsIgnoreCase("matlab")) {
            printMatlab(printStream, dMatrix);
            return;
        }
        if (str.equalsIgnoreCase("java")) {
            printJava(printStream, dMatrix, str);
            return;
        }
        printTypeSize(printStream, dMatrix);
        String str2 = str + " ";
        for (int i = 0; i < dMatrix.getNumRows(); i++) {
            for (int i2 = 0; i2 < dMatrix.getNumCols(); i2++) {
                printStream.printf(local, str2, Double.valueOf(dMatrix.get(i, i2)));
            }
            printStream.println();
        }
    }

    public static void printMatlab(PrintStream printStream, DMatrix dMatrix) {
        printStream.print("[ ");
        int i = 0;
        while (i < dMatrix.getNumRows()) {
            int i2 = 0;
            while (i2 < dMatrix.getNumCols()) {
                printStream.printf(local, "%.12E", Double.valueOf(dMatrix.get(i, i2)));
                i2++;
                if (i2 < dMatrix.getNumCols()) {
                    printStream.print(" , ");
                }
            }
            i++;
            if (i < dMatrix.getNumRows()) {
                printStream.println(" ;");
            } else {
                printStream.println(" ]");
            }
        }
    }

    public static void printMatlab(PrintStream printStream, FMatrix fMatrix) {
        printStream.print("[ ");
        int i = 0;
        while (i < fMatrix.getNumRows()) {
            int i2 = 0;
            while (i2 < fMatrix.getNumCols()) {
                printStream.printf(local, MATLAB_FORMAT, Float.valueOf(fMatrix.get(i, i2)));
                i2++;
                if (i2 < fMatrix.getNumCols()) {
                    printStream.print(" , ");
                }
            }
            i++;
            if (i < fMatrix.getNumRows()) {
                printStream.println(" ;");
            } else {
                printStream.println(" ]");
            }
        }
    }

    public static void print(PrintStream printStream, DMatrixSparseCSC dMatrixSparseCSC, String str) {
        if (str.equalsIgnoreCase("matlab")) {
            printMatlab(printStream, dMatrixSparseCSC);
            return;
        }
        printTypeSize(printStream, dMatrixSparseCSC);
        int length = String.format(str, Double.valueOf(-1.1123d)).length();
        char[] cArr = new char[length];
        Arrays.fill(cArr, ' ');
        cArr[length / 2] = '*';
        for (int i = 0; i < dMatrixSparseCSC.numRows; i++) {
            for (int i2 = 0; i2 < dMatrixSparseCSC.numCols; i2++) {
                int iNz_index = dMatrixSparseCSC.nz_index(i, i2);
                if (iNz_index >= 0) {
                    printStream.printf(local, str, Double.valueOf(dMatrixSparseCSC.nz_values[iNz_index]));
                } else {
                    printStream.print(cArr);
                }
                if (i2 != dMatrixSparseCSC.numCols - 1) {
                    printStream.print(" ");
                }
            }
            printStream.println();
        }
    }

    public static void print(PrintStream printStream, FMatrixSparseCSC fMatrixSparseCSC, String str) {
        if (str.equalsIgnoreCase("matlab")) {
            printMatlab(printStream, fMatrixSparseCSC);
            return;
        }
        printTypeSize(printStream, fMatrixSparseCSC);
        int length = String.format(str, Double.valueOf(-1.1123d)).length();
        char[] cArr = new char[length];
        Arrays.fill(cArr, ' ');
        cArr[length / 2] = '*';
        for (int i = 0; i < fMatrixSparseCSC.numRows; i++) {
            for (int i2 = 0; i2 < fMatrixSparseCSC.numCols; i2++) {
                int iNz_index = fMatrixSparseCSC.nz_index(i, i2);
                if (iNz_index >= 0) {
                    printStream.printf(local, str, Float.valueOf(fMatrixSparseCSC.nz_values[iNz_index]));
                } else {
                    printStream.print(cArr);
                }
                if (i2 != fMatrixSparseCSC.numCols - 1) {
                    printStream.print(" ");
                }
            }
            printStream.println();
        }
    }

    public static void print(PrintStream printStream, DMatrixSparseTriplet dMatrixSparseTriplet, String str) {
        printTypeSize(printStream, dMatrixSparseTriplet);
        throw null;
    }

    public static void print(PrintStream printStream, FMatrixSparseTriplet fMatrixSparseTriplet, String str) {
        printTypeSize(printStream, fMatrixSparseTriplet);
        throw null;
    }

    public static void printJava(PrintStream printStream, DMatrix dMatrix, String str) {
        printStream.println("new " + (dMatrix.getType().getBits() == 64 ? "double" : "float") + "[][]{");
        StringBuilder sb = new StringBuilder();
        sb.append(str);
        sb.append(" ");
        String string = sb.toString();
        int i = 0;
        while (i < dMatrix.getNumRows()) {
            printStream.print("{");
            int i2 = 0;
            while (i2 < dMatrix.getNumCols()) {
                printStream.printf(local, string, Double.valueOf(dMatrix.get(i, i2)));
                i2++;
                if (i2 < dMatrix.getNumCols()) {
                    printStream.print(", ");
                }
            }
            i++;
            if (i < dMatrix.getNumRows()) {
                printStream.println("},");
            } else {
                printStream.println("}};");
            }
        }
    }

    public static void print(PrintStream printStream, FMatrix fMatrix) {
        print(printStream, fMatrix, "%11.4E");
    }

    public static void print(PrintStream printStream, FMatrix fMatrix, String str) {
        if (str.equalsIgnoreCase("matlab")) {
            printMatlab(printStream, fMatrix);
            return;
        }
        if (str.equalsIgnoreCase("java")) {
            printJava(printStream, fMatrix, str);
            return;
        }
        printTypeSize(printStream, fMatrix);
        String str2 = str + " ";
        for (int i = 0; i < fMatrix.getNumRows(); i++) {
            for (int i2 = 0; i2 < fMatrix.getNumCols(); i2++) {
                printStream.printf(local, str2, Float.valueOf(fMatrix.get(i, i2)));
            }
            printStream.println();
        }
    }

    public static void printJava(PrintStream printStream, FMatrix fMatrix, String str) {
        printStream.println("new " + (fMatrix.getType().getBits() == 64 ? "double" : "float") + "[][]{");
        StringBuilder sb = new StringBuilder();
        sb.append(str);
        sb.append(" ");
        String string = sb.toString();
        int i = 0;
        while (i < fMatrix.getNumRows()) {
            printStream.print("{");
            int i2 = 0;
            while (i2 < fMatrix.getNumCols()) {
                printStream.printf(local, string, Float.valueOf(fMatrix.get(i, i2)));
                i2++;
                if (i2 < fMatrix.getNumCols()) {
                    printStream.print(", ");
                }
            }
            i++;
            if (i < fMatrix.getNumRows()) {
                printStream.println("},");
            } else {
                printStream.println("}};");
            }
        }
    }

    public static void print(PrintStream printStream, ZMatrix zMatrix, String str) {
        printTypeSize(printStream, zMatrix);
        String str2 = str + " + " + str + "i";
        Complex_F64 complex_F64 = new Complex_F64();
        for (int i = 0; i < zMatrix.getNumRows(); i++) {
            for (int i2 = 0; i2 < zMatrix.getNumCols(); i2++) {
                zMatrix.get(i, i2, complex_F64);
                printStream.printf(local, str2, Double.valueOf(complex_F64.real), Double.valueOf(complex_F64.imaginary));
                if (i2 < zMatrix.getNumCols() - 1) {
                    printStream.print(" , ");
                }
            }
            printStream.println();
        }
    }

    private static void printTypeSize(PrintStream printStream, Matrix matrix) {
        if (matrix instanceof MatrixSparse) {
            MatrixSparse matrixSparse = (MatrixSparse) matrix;
            printStream.println("Type = " + getMatrixType(matrix) + " , rows = " + matrix.getNumRows() + " , cols = " + matrix.getNumCols() + " , nz_length = " + matrixSparse.getNonZeroLength());
            return;
        }
        printStream.println("Type = " + getMatrixType(matrix) + " , rows = " + matrix.getNumRows() + " , cols = " + matrix.getNumCols());
    }

    public static void print(PrintStream printStream, CMatrix cMatrix, String str) {
        printTypeSize(printStream, cMatrix);
        String str2 = str + " ";
        Complex_F32 complex_F32 = new Complex_F32();
        for (int i = 0; i < cMatrix.getNumRows(); i++) {
            for (int i2 = 0; i2 < cMatrix.getNumCols(); i2++) {
                cMatrix.get(i, i2, complex_F32);
                printStream.printf(local, str2, Float.valueOf(complex_F32.real), Float.valueOf(complex_F32.imaginary));
                if (i2 < cMatrix.getNumCols() - 1) {
                    printStream.print(" , ");
                }
            }
            printStream.println();
        }
    }

    private static String getMatrixType(Matrix matrix) {
        if (matrix.getType() == MatrixType.UNSPECIFIED) {
            return matrix.getClass().getSimpleName();
        }
        return matrix.getType().name();
    }
}
